using Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;
using Illegible_Cms_V2.Identity.Domain.Roles;

namespace Illegible_Cms_V2.Identity.Persistence.Extensions;

public static class RoleQueryableExtension
{
    public static IQueryable<Role> ApplyFilter(this IQueryable<Role> query, RoleFilter filter)
    {
        // Filter by permission ids
        if (filter.PermissionIds != null)
            query = query.Where(x => x.RolePermission.Any(x => filter.PermissionIds.Contains(x.PermissionId)));

        // Filter by title
        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower().Trim()));

        return query;
    }

    public static IQueryable<Role> ApplySort(this IQueryable<Role> query, RoleSortBy? sortBy)
    {
        return sortBy switch
        {
            RoleSortBy.CreationDate => query.OrderBy(x => x.CreatedAt),
            RoleSortBy.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}