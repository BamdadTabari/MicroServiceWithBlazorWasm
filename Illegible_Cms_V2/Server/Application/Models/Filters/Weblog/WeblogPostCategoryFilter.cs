using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Server.Application.Models.Filters.Weblog
{
    public class WeblogPostCategoryFilter: PaginationFilter
    {
        public WeblogPostCategoryFilter(int page, int pageSize): base(page, pageSize)
        {
        }
        public string KeyWord { get; set; }
        public WeblogPostCategorySortBy sortBy { get; set; }
    }
}
