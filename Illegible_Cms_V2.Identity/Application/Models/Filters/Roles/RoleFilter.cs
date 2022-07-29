using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;

public class RoleFilter : PaginationFilter
{
    public RoleFilter(int page, int pageSize) : base(page, pageSize)
    {
    }

    public string Title { get; set; }
    public int[] PermissionIds { get; set; }
    public RoleIncludes Include { get; set; }
    public RoleSortBy? SortBy { get; set; }
}