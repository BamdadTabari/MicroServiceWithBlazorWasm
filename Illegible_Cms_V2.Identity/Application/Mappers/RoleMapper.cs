using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Domain.Roles;

namespace Illegible_Cms_V2.Identity.Application.Mappers
{
    public static class RoleMapper
    {
        public static RoleModel MapToRoleModel(this Role role)
        {
            var permission = role.RolePermission?.Select(x => x.Permission)
                .MapToPermissionModels().ToList();
            return new RoleModel
            {
                Id = role.Id,
                Name = role.Name,
                Title = role.Title,
                Permissions = permission ?? new List<PermissionModel>()
            };
        }

        public static IEnumerable<RoleModel> MapToRoleModels(this IEnumerable<Role> roles)
        {
            foreach (var role in roles)
                yield return role.MapToRoleModel();
        }
    }
}