using Illegible_Cms_V2.Client.ClientObjects.Filters.Server.BlogPostFilters;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Client.ClientObjects.Requests.Server.BlogPostRequests;

public class GetBlogPostByFilterRequest : PaginationFilter
{
    protected GetBlogPostByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetBlogPostByFilterRequest()
    {
    }

    public string? Keyword { get; set; }
    public BlogPostSortBy SortBy { get; set; }
}