using Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Permissions;
using Illegible_Cms_V2.Identity.Domain.Permissions;
using Illegible_Cms_V2.Identity.Persistence.Extensions;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Persistence.Repositories.Permissions;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    private readonly IQueryable<Permission> _queryable;

    public PermissionRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<Permission>();
    }

    public async Task<Permission> GetPermissionByIdAsync(int id)
    {
        return await _queryable
            .Include(x => x.Roles)
            .SingleOrDefaultAsync(x => x.Id == id) ?? new Permission();
    }

    public async Task<List<Permission>> GetPermissionsByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;

        query = query.AsNoTracking()
            .Include(x => x.Roles);

        // Filter by ids
        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        return await query.ToListAsync();
    }

    public async Task<List<Permission>> GetPermissionsByFilterAsync(PermissionFilter filter)
    {
        try
        {
            var query = _queryable;

            query = query.AsNoTracking()
                .Include(x => x.Roles);

            query = query.ApplyFilter(filter);
            query = query.ApplySort();

            return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<int> CountPermissionsByFilterAsync(PermissionFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking()
            .Include(x => x.Roles);

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }
}