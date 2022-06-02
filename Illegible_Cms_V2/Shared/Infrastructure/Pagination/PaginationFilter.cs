using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illegible_Cms_V2.Shared.Infrastructure.Pagination
{
    public class PaginationFilter
    {
        private const int MinPageNumber = 1;
        private const int MaxPageSize = 200;

        protected PaginationFilter(int page, int pageSize)
        {
            Page = page > 0 ? page : MinPageNumber;
            PageSize = pageSize > 0 && pageSize <= MaxPageSize ? pageSize : MaxPageSize;
        }
        protected PaginationFilter()
        {
        }
        public int Page { get; }
        public int PageSize { get; }
    }
}
