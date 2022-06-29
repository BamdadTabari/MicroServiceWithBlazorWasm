using Illegible_Cms_V2.Identity.Application.Models.Filters.Permissions;
using Illegible_Cms_V2.Identity.Domain.Permissions;

namespace Illegible_Cms_V2.Identity.Application.Interfaces.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<List<Permission>> GetPermissionsByIdsAsync(IEnumerable<int> ids);
        Task<List<Permission>> GetPermissionsByFilterAsync(PermissionFilter filter);
        Task<int> CountPermissionsByFilterAsync(PermissionFilter filter);
    }
}
