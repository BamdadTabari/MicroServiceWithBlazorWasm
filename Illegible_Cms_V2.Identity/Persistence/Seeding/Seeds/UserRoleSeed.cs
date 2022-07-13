using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Persistence.Seeding.Seeds
{
    internal static class UserRoleSeed
    {
        public static List<UserRole> All => new List<UserRole>
        {
            new UserRole()
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
