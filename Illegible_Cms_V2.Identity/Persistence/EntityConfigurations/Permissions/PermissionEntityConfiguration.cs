using Illegible_Cms_V2.Identity.Domain.Permissions;
using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Illegible_Cms_V2.Identity.Persistence.EntityConfigurations.Permissions
{
    internal class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);

            #region Mappings

            builder.Property(b => b.Value)
                .HasMaxLength(Defaults.NameLength)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(Defaults.TitleLength);

            #endregion

            #region Navigations
            builder.HasOne(x=>x.Creator).WithOne(x=>x.User)
            #endregion
        }
    }
}
