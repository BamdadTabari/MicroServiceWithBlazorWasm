using Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;
using Illegible_Cms_V2.Identity.Domain.Roles;

namespace Illegible_Cms_V2.Identity.Application.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetRoleByIdAsync(int id);
        Task<List<Role>> GetRolesByIdsAsync(IEnumerable<int> ids);
        Task<List<Role>> GetRolesByFilterAsync(RoleFilter filter);
        Task<int> CountRolesByFilterAsync(RoleFilter filter);
    }
}
