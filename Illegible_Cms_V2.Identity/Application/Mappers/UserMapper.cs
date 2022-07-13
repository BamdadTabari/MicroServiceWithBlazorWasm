using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Application.Models.Base.Claims;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Application.Mappers
{
    public static class UserMapper
    {
        public static UserModel MapToUserModel(this User user)
        {
            var roles = user.UserRoles?.Select(x => x.Role).MapToRoleModels().ToList();
            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsEmailConfirmed = user.IsEmailConfirmed,
                State = user.State,
                IsLockedOut = user.IsLockedOut(),
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                ConcurrencyStamp = user.ConcurrencyStamp,
                FailedLoginCount = user.FailedLoginCount,
                IsMobileConfirmed = user.IsMobileConfirmed,
                LastLoginDate = user.LastLoginDate,
                Claims = (ICollection<ClaimModel>)user.Claims,
                LastPasswordChangeTime = user.LastPasswordChangeTime,
                LockoutEndTime = user.LockoutEndTime,
                Mobile = user.Mobile,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserRoles = (ICollection<UserRoleModel>)(ICollection<UserRole>)(roles ?? new List<RoleModel>())
            };
        }

        public static IEnumerable<UserModel> MapToUserModels(this IEnumerable<User> users)
        {
            foreach (var user in users)
                yield return user.MapToUserModel();
        }
    }
}
