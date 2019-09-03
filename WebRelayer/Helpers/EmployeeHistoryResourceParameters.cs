using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Helpers
{
    public class EmployeeHistoryResourceParameters
    {
        private const int _maxPageSize = 20;

        private int _pageSize = 10;

        public int Page { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > _maxPageSize ? _maxPageSize : value;
            }
        }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}
