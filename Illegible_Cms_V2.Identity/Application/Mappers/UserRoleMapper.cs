using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Application.Mappers
{
    public static class UserRoleMapper
    {
        public static UserRoleModel MapToUserRoleModel(this UserRole userRole)
        {
            return new UserRoleModel()
            {
                CreatedAt = userRole.CreatedAt,
                UpdatedAt = userRole.UpdatedAt,
                RoleId = userRole.RoleId,
                UserId = userRole.UserId,
                Role = userRole.Role.MapToRoleModel(),
                User = userRole.User.MapToUserModel()
            };
        }

        public static IEnumerable<UserRoleModel> MapToUserRoleModels(this IEnumerable<UserRole> userRoles)
        {
            foreach (var userRole in userRoles)
                yield return userRole.MapToUserRoleModel();
        }
    }
}
