using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Domain.Permissions;
using Illegible_Cms_V2.Identity.Domain.Roles;

namespace Illegible_Cms_V2.Identity.Application.Mappers
{
    public static class PermissionMapper
    {
        public static PermissionModel MapToPermissionModel(this Permission permission)
        {
            return new PermissionModel
            {
                Id = permission.Id,
                Value = permission.Value,
                Title = permission.Title,
                Name = permission.Name,
                CreatedAt = permission.CreatedAt,
                CreatorId = permission.CreatorId,
                Creator = permission.Creator.MapToUserModel(),
                Roles = (ICollection<RolePermissionModel>)
                    ((IEnumerable<Role>)permission.Roles).MapToRoleModels(),
            };
        }

        public static IEnumerable<PermissionModel> MapToPermissionModels(this IEnumerable<Permission> permissions)
        {
            foreach (var permission in permissions)
                yield return permission.MapToPermissionModel();
        }
    }
}
