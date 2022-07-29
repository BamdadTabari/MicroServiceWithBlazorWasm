using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Illegible_Cms_V2.Server.Persistence.EntityConfigurations.Weblog;

public class WeblogPostCategoryEntityConfiguration : IEntityTypeConfiguration<WeblogPostCategory>
{
    public void Configure(EntityTypeBuilder<WeblogPostCategory> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.CategoryTitle).IsRequired()
            .HasMaxLength(Defaults.TinyLength);

        builder.Property(e => e.CategoryIcon)
            .IsRequired();
        #endregion

    }

}