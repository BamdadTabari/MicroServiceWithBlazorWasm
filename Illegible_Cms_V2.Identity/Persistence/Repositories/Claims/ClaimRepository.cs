using Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Claims;
using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Identity.Persistence.Extensions;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Persistence.Repositories.Claims;

public class ClaimRepository : Repository<Claim>, IClaimRepository
{
    private readonly IQueryable<Claim> _queryable;

    public ClaimRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<Claim>();
    }

    public async Task<Claim> GetClaimByIdAsync(int id)
    {
        return await _queryable
            .SingleOrDefaultAsync(x => x.Id == id) ?? new Claim();
    }

    public async Task<List<Claim>> GetClaimsByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        // Filter by ids
        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        return await query.ToListAsync();
    }

    public async Task<List<Claim>> GetClaimsByFilterAsync(ClaimFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<int> CountClaimsByFilterAsync(ClaimFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }
}