using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Domain.Roles;

namespace Illegible_Cms_V2.Identity.Application.Helpers
{
    public static class RoleHelper
    {

        public static Role CreateRole(CreateRoleCommand command) => new Role
        {
            Name = command.Name,
            Title = command.Title,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatorId = command.RequestInfo.UserId,
            UpdaterId = command.RequestInfo.UserId,
        };

        public static RolePermission CreateRolePermission(int permissionId, int creatorId, int roleId)
        {
            return new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId,
                CreatedAt = DateTime.Now,
                CreatorId = creatorId
            };
        }

    }
}
