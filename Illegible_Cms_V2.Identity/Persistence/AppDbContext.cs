using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Identity.Domain.Permissions;
using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Persistence
{
    public sealed class AppDbContext : DbContext
    {
        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // Creating Model
            base.OnModelCreating(modelBuilder);
        }
    }
}
