using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Domain.Permissions;

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
                CreatorName = permission.CreatorName,
                CreatorId = permission.CreatorId
            };
        }

        public static IEnumerable<PermissionModel> MapToPermissionModels(this IEnumerable<Permission> permissions)
        {
            foreach (var permission in permissions)
                yield return permission.MapToPermissionModel();
        }
    }
}
