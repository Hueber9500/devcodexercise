using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;
using WebRelayer.Entities;

namespace WebRelayer.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppCtx context) : base(context)
        {
        }


        public async Task<List<Employee>> ListAsync() => 
            await _context.Employees.ToListAsync();

        public async Task<List<Employee>> ListByIdsAsync(IEnumerable<int> ids) =>
            await _context.Employees.Where(e => ids.Contains(e.Id)).ToListAsync();
    }
}
