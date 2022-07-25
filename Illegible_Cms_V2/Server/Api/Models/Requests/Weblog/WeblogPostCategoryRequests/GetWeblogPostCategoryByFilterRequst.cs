using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostCategoryFilters;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Server.Api.Models.Requests.Weblog.WeblogPostCategoryRequests
{
    public class GetWeblogPostCategoryByFilterRequst : PaginationFilter
    {
        protected GetWeblogPostCategoryByFilterRequst(int page, int pageSize) : base(page, pageSize)
        {
        }

        public GetWeblogPostCategoryByFilterRequst()
        {
        }

        public string? Keyword { get; set; }
        public WeblogPostCategorySortBy SortBy { get; set; }
    }
}