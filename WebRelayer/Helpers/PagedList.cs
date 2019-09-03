using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> items, int currentPage, int pageSize, int totalCount)
        {
            AddRange(items);
            CurrentPage = currentPage; 
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = TotalCount > 0 ? (int)Math.Ceiling((TotalCount / (double)PageSize)) : 0;
        }

        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, pageNumber, pageSize, count);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, pageNumber, pageSize, count);
        }
    }
}
