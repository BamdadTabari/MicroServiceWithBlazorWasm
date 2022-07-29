using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Identity.Application.Models.Filters.Permissions;

public class PermissionFilter : PaginationFilter
{
    public PermissionFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public int? RoleId { get; set; }
    public string? Value { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
}