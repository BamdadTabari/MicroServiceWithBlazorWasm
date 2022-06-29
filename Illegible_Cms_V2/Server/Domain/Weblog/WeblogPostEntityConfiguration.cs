using Illegible_Cms_V2.Shared.BasicShared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Illegible_Cms_V2.Server.Domain.Weblog
{
    internal class WeblogPostEntityConfiguration: IEntityTypeConfiguration<WeblogPost>
    {
        public void Configure(EntityTypeBuilder<WeblogPost> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title).IsRequired()
                .HasMaxLength(Defaults.TinyLength);

            builder.Property(e => e.Summery).IsRequired()
                .HasMaxLength(Defaults.MidLength);

            builder.Property(e => e.TextContent).IsRequired()
                .HasMaxLength(Defaults.HugeLength);
        }

    }
}
