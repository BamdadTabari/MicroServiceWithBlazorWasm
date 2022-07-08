using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Domain.Roles;
namespace Illegible_Cms_V2.Identity.Application.Mappers
{
    public static class RoleMapper
    {
        public static RoleModel MapToRoleModel(this Role role)
        {
            //var permission = role.RolePermission?.Select(x => x.Permission)
            //    .MapToPermissionModels().ToList();
            return new RoleModel
            {
                Id = role.Id,
                Title = role.Title,
                Permissions = role?.RolePermission as List<PermissionModel> ?? new List<PermissionModel>(),
                RolePermission = role?.RolePermission as List<RolePermissionModel> ?? new List<RolePermissionModel>(),
                CreatedAt = role != null ? role.CreatedAt : DateTime.Now,
                UpdatedAt = role != null ? role.UpdatedAt : DateTime.Now,
                UserRoles = (ICollection<UserRoleModel>)
                    (role !=null ? role.UserRoles.MapToUserRoleModels() : new List<UserRoleModel>()),
            };
        }

        public static IEnumerable<RoleModel> MapToRoleModels(this IEnumerable<Role> roles)
        {
            foreach (var role in roles)
                yield return role.MapToRoleModel();
        }
    }
}