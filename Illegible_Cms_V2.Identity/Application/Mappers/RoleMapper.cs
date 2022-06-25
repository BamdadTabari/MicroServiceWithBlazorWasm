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
                Name = role.Name,
                Title = role.Title,
                Permissions = role?.RolePermission as List<PermissionModel> ?? new List<PermissionModel>(),
                RolePermission = role?.RolePermission as List<RolePermissionModel> ?? new List<RolePermissionModel>(),
                CreatedAt = role != null ? role.CreatedAt : DateTime.Now,
                IsArchived = role != null && role.IsArchived,
                Creator = role != null ? role.Creator.MapToUserModel() : new UserModel(),
                CreatorId = role != null ? role.CreatorId : 0,
                IsDeleted = role != null && role.IsDeleted,
                UpdatedAt = role != null ? role.UpdatedAt : DateTime.Now,
                UpdaterId = role != null ? role.UpdaterId : 0,
                Updater = role != null ? role.Updater.MapToUserModel() : new UserModel(),
               // UserRoles = role !=null ? role.UserRoles.MapTo : new List<UserRoleModel>(),
            };
        }

        public static IEnumerable<RoleModel> MapToRoleModels(this IEnumerable<Role> roles)
        {
            foreach (var role in roles)
                yield return role.MapToRoleModel();
        }
    }
}