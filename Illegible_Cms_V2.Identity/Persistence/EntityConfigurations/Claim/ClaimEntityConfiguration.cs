using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Illegible_Cms_V2.Identity.Persistence.EntityConfigurations.Claim
{
    internal class ClaimEntityConfiguration : IEntityTypeConfiguration<Domain.Claims.Claim>
    {
        public void Configure(EntityTypeBuilder<Domain.Claims.Claim> builder)
        {
            builder.HasKey(x => x.Id);
            
            #region Mappings

            builder.Property(b => b.Value)
                .HasMaxLength(Defaults.BigLength)
                .IsRequired();

            #endregion

            #region Conversions

            builder.Property(x => x.Type)
                .HasConversion(new EnumToStringConverter<ClaimType>())
                .HasMaxLength(ClaimType.Permission.GetMaxLength());

            #endregion

            #region Navigations

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
