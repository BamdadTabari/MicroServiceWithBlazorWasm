using Illegible_Cms_V2.Server.Domain.Weblog;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Server.Persistence
{
    public class AppDbContext: DbContext
    {
        #region DbSets
        public DbSet<WeblogPost> WeblogPosts { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
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
