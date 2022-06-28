using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Illegible_Cms_V2.Identity.Persistence.EntityConfigurations.Roles
{
    internal class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);

            #region Mappings

            builder.Property(b => b.Name)
                .HasMaxLength(Defaults.TitleLength);

            #endregion

            #region Navigations

            //builder
            //    .HasMany(x => x.UserRoles)
            //    .WithOne(x => x.Role)
            //    .HasForeignKey(x => x.RoleId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Updater)
                .WithMany()
                .HasForeignKey(x => x.UpdaterId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasMany(x => x.RolePermission)
            //    .WithOne(x => x.Role)
            //    .HasForeignKey(x => x.RoleId)
            //    .OnDelete(DeleteBehavior.Restrict);

            #endregion

        }
    }
}
