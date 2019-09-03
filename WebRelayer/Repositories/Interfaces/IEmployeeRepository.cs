using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Entities;

namespace WebRelayer.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> ListAsync();

        Task<List<Employee>> ListByIdsAsync(IEnumerable<int> ids);
    }
}
