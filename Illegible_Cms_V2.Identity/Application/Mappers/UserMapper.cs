using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
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
                LastPasswordChangeDate = user.LastPasswordChangeTime,

                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,

                Roles = roles ?? new List<RoleModel>()
            };
        }

        public static IEnumerable<UserModel> MapToUserModels(this IEnumerable<User> users)
        {
            foreach (var user in users)
                yield return user.MapToUserModel();
        }
    }
}
