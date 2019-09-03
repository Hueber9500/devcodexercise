using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Entities;

namespace WebRelayer.Helpers
{
    public class EmployeeTeamEqualityComparer : IEqualityComparer<EmployeeTeam>
    {
        public bool Equals(EmployeeTeam x, EmployeeTeam y)
        {
            return x.Employee == y.Employee && x.Team == y.Team;
        }

        public int GetHashCode(EmployeeTeam obj)
        {
            return obj.GetHashCode();
        }
    }
}
