using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Domain.Roles;
namespace Illegible_Cms_V2.Identity.Application.Mappers
{
    public static class RoleMapper
    {
        public static RoleModel MapToRoleModel(this Role role, int iteration = 0)
        {
            // for avoiding infinity loop on nested maps
            var userRole = new List<UserRoleModel>();
            if (iteration == 0)
            {
                userRole = role != null ? role.UserRoles.MapToUserRoleModels().ToList() : new List<UserRoleModel>();
                iteration++;
            }

            var permission = role.RolePermission?.Select(x => x.Permission)
                .MapToPermissionModels().ToList();
            return new RoleModel
            {
                Id = role.Id,
                Title = role.Title,
                Permissions = permission,
                RolePermission = role?.RolePermission as List<RolePermissionModel> ?? new List<RolePermissionModel>(),
                CreatedAt = role != null ? role.CreatedAt : DateTime.Now,
                UpdatedAt = role != null ? role.UpdatedAt : DateTime.Now,
                UserRoles = userRole
            };
        }

        public static IEnumerable<RoleModel> MapToRoleModels(this IEnumerable<Role> roles)
        {
            foreach (var role in roles)
                yield return role.MapToRoleModel();
        }
    }
}