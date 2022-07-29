using Illegible_Cms_V2.Identity.Application.Models.Filters.Users;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByUsernameAsync(string username);
    Task<int> CountUsersByFilterAsync(UserFilter filter);
    Task<List<User>> GetUsersByIdsAsync(IEnumerable<int> ids);
    Task<List<User>> GetUsersByFilterAsync(UserFilter filter);
}