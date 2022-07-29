using Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Users;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Identity.Persistence.Extensions;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Persistence.Repositories.Users;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IQueryable<User> _queryable;

    public UserRepository(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<User>();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _queryable
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new NullReferenceException("user not found with this id");

        return user;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await _queryable
            .Include(x => x.UserRoles)
            .SingleOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());

        if (user == null)
            throw new NullReferenceException("user not found with this name ");

        return user;
    }

    public async Task<int> CountUsersByFilterAsync(UserFilter filter)
    {
        var query = _queryable;

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }

    public async Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;
        query = query.AsNoTracking()
            .Include(x => x.UserRoles);

        // Filter by ids
        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        query = query.ApplySort(UserSortBy.CreationDate);

        return await query.ToListAsync();
    }

    public async Task<List<User>> GetUsersByFilterAsync(UserFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();

        // Includes
        if (filter.Include is { Role: true }) query = query.Include(x => x.UserRoles);

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }
}