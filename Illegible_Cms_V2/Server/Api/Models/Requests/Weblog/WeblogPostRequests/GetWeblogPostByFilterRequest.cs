using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostFilters;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Server.Api.Models.Requests.Weblog.WeblogPostRequests
{
    public class GetWeblogPostByFilterRequest : PaginationFilter
    {
        protected GetWeblogPostByFilterRequest(int page, int pageSize) : base(page, pageSize)
        {
        }

        public GetWeblogPostByFilterRequest()
        {
        }

        public string? Keyword { get; set; }
        public WeblogPostSortBy? SortBy { get; set; }
    }
}
