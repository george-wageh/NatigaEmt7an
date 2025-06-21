using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Contracts.Responses;

namespace NatigaEmt7an.Api.Helper
{
    public static class PaginationHelper
    {
        public static async Task<PageList<T>> MapPageList<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PageList<T>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                Data = data,
            };
        }
    }
}
