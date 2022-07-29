using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Identity.Application.Models.Filters.Claims;

public class ClaimFilter : PaginationFilter
{
    protected ClaimFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public int? UserId { get; set; }
    public string? Value { get; set; }
    public ClaimSortBy? SortBy { get; set; }

}