using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;
using WebRelayer.DomainModels;
using WebRelayer.Entities;
using WebRelayer.Helpers;
using WebRelayer.Repositories;

namespace WebRelayer.Services
{
    public class SeedService : ISeedService
    {
        public void Seed(string fileName, AppCtx db)
        {
            try
            {
                IList<JsonEmployee> employees = null;
                employees = JsonConvert.DeserializeObject<IList<JsonEmployee>>(new StreamReader(fileName).ReadToEnd());

                Dictionary<string, Team> mapOfTeams = new Dictionary<string, Team>(new StringKeyComparer());
                Dictionary<string, Role> mapOfRoles = new Dictionary<string, Role>(new StringKeyComparer());

                

                List<Employee> dbEmployees = new List<Employee>();

                foreach(var je in employees)
                {
                    var dbEmployee = new Employee()
                    {
                        Age = je.Age,
                        FirstName = je.Name,
                        ManagerId = je.ManagerId,        
                        Surname = je.SurName
                    };

                    AddIfNotExistsInDictionary<Role>(je.Role, mapOfRoles);

                    je.Teams.ForEach(t => AddIfNotExistsInDictionary(t, mapOfTeams));

                    dbEmployee.Role = mapOfRoles[je.Role.ToLower()];
                    dbEmployee.Teams = je.Teams
                        .Select(t => t.ToLower())
                        .Distinct()
                        .Select(t => new EmployeeTeam() { Employee = dbEmployee, Team = mapOfTeams[t] })
                        .ToList();

                    dbEmployees.Add(dbEmployee);
                }

                db.Database.OpenConnection();
                db.Database.ExecuteSqlCommand("DBCC checkident ('dbo.Employee', reseed, 0)");

                int count = 0;
                foreach (var dbEm in dbEmployees)
                {
                    db.Employees.Add(dbEm);
                    count++;

                    if(count == 10)
                    {
                        db.SaveChanges();
                        count = 0;
                    }
                }

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Database.CloseConnection();
            }

        }

        private void AddIfNotExistsInDictionary<T>(string element, Dictionary<string, T> dictionary) where T : new()
        {
            if (!dictionary.ContainsKey(element.ToLower()))
            {
                string key = element.ToLower();

                dynamic obj = new T();
                obj.Name = key.FirstCharToUpper();
                dictionary.Add(key, obj);
            }
        }
    }
}
