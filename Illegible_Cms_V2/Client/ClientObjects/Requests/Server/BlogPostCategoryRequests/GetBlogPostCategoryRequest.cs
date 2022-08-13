using Illegible_Cms_V2.Client.ClientObjects.Filters.Server.BlogPostCategoryFilters;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Client.ClientObjects.Requests.Server.BlogPostCategoryRequests;

internal class GetBlogPostCategoryRequest:PaginationFilter
{
    protected GetBlogPostCategoryRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetBlogPostCategoryRequest()
    {
    }

    public string? Keyword { get; set; }
    public BlogPostCategorySortBy SortBy { get; set; }
}
