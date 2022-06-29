using Illegible_Cms_V2.Identity.Persistence.Seeding.Seeds;

namespace Illegible_Cms_V2.Identity.Persistence.Seeding
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scoped = serviceProvider.CreateScope();
            var context = scoped.ServiceProvider.GetRequiredService<AppDbContext>();

            // Users manual Seed
            UserSeed.Run(scoped);

            // Role manual Seed
            RoleSeed.Run(scoped);

            context.SaveChanges();
        }
    }
}
