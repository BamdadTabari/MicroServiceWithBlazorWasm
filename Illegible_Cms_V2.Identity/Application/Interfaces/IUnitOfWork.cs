using Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;

namespace Illegible_Cms_V2.Identity.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IClaimRepository Claims { get; }
        IPermissionRepository Permissions { get; }

        Task<bool> CommitAsync();
    }
}
