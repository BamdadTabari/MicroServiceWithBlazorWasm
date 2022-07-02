using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Server.Application.Models.Filters.Weblog
{
    public class WeblogPostFilter: PaginationFilter
    {
        protected WeblogPostFilter(int page, int pageSize) : base(page, pageSize)
        {

        }

        public string KeyWord { get; set; }

        public WeblogPostSortBy? SortBy { get; set; }

    }
}
