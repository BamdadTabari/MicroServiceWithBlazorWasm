using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants;

namespace Illegible_Cms_V2.Identity.Persistence.Seeding.Seeds
{
    internal static class UserSeed
    {
        public static List<User> All => new List<User>()
        {
            new User()
            {
                Id = 1,
                IsMobileConfirmed = false,
                IsEmailConfirmed = false,
                Email = "mohammadJavadtabari1024@outlook.com",
                Mobile = "09301724389",
                State = UserState.Active,
                Username = "Illegible_Owner",
                PasswordHash = new PasswordHasher().Hash("owner"),
                ConcurrencyStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
                SecurityStamp = StampGenerator.CreateSecurityStamp(Defaults.SecurityStampLength),
                IsDeleted = false,
                LastPasswordChangeTime = DateTime.UtcNow,
                CreatorId = 1,
                UpdaterId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
    }
}
