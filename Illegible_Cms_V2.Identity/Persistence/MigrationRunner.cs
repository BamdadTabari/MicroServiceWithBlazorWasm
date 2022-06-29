using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Persistence
{
    internal static class MigrationRunner
    {
        public static void Run(IServiceProvider serviceProvider)
        {
            using var scoped = serviceProvider.CreateScope();
            var context = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
