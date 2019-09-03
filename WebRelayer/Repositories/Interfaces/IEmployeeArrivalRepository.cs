using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Entities;
using WebRelayer.Helpers;

namespace WebRelayer.Repositories
{
    public interface IEmployeeArrivalRepository
    {
        Task AddRangeAsync(IEnumerable<EmployeeArrival> informationModels);

        Task<PagedList<EmployeeArrival>> ListEmployeeArrivalsHistoryAsync(EmployeeHistoryResourceParameters resourceParameters);
    }
}
