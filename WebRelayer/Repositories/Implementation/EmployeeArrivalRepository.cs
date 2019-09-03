using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Database_Contexts;
using WebRelayer.Entities;
using WebRelayer.Helpers;

namespace WebRelayer.Repositories
{
    public class EmployeeArrivalRepository : IEmployeeArrivalRepository
    {
        private AppCtx _context;

        public EmployeeArrivalRepository(AppCtx context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<EmployeeArrival> informationModels)
        {
            await _context.AddRangeAsync(informationModels);
        }

        public async Task<PagedList<EmployeeArrival>> ListEmployeeArrivalsHistoryAsync(EmployeeHistoryResourceParameters resourceParameters)
        {
            var collection = _context.EmployeeArrival.AsQueryable();

            if (!string.IsNullOrWhiteSpace(resourceParameters.FirstName))
                collection = _context.EmployeeArrival
                    .Where(ea => ea.Employee.FirstName.Equals(resourceParameters.FirstName));

            if (!string.IsNullOrWhiteSpace(resourceParameters.Surname))
                collection = _context.EmployeeArrival
                    .Where(ea => ea.Employee.Surname.Equals(resourceParameters.Surname));

            collection = collection.Include(ea => ea.Employee);

            return await PagedList<EmployeeArrival>.CreateAsync(collection,  resourceParameters.Page, resourceParameters.PageSize);
        }
    }
}
