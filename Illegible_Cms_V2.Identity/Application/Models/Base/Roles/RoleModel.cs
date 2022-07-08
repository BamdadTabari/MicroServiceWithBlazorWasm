using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Roles
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatorId { get; set; }
        public int UpdaterId { get; set; }

        public ICollection<UserRoleModel> UserRoles { get; set; }
        public ICollection<RolePermissionModel> RolePermission { get; set; }
        public UserModel Creator { get; set; }
        public UserModel Updater { get; set; }
        public List<PermissionModel> Permissions { get; internal set; }
    }
}
