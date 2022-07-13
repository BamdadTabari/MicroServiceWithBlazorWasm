using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Interfaces.Repositories;
using Illegible_Cms_V2.Identity.Persistence.Repositories.Claims;
using Illegible_Cms_V2.Identity.Persistence.Repositories.Permissions;
using Illegible_Cms_V2.Identity.Persistence.Repositories.Roles;
using Illegible_Cms_V2.Identity.Persistence.Repositories.Users;

namespace Illegible_Cms_V2.Identity.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IClaimRepository Claims { get; }
        public IPermissionRepository Permissions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            Claims = new ClaimRepository(_context);
            Permissions = new PermissionRepository(_context);


        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
