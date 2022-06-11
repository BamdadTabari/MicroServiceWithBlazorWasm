using Illegible_Cms_V2.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Illegible_Cms_V2.Identity.Persistence.EntityConfigurations.Roles
{
    internal class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.PermissionId });

            builder.HasQueryFilter(x => !x.IsDeleted);

            #region Navigations

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.RolePermission)
                .HasForeignKey(x => x.RoleId);

            builder
                .HasOne(x => x.Permission)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.PermissionId);

            #endregion

        }
    }
}
