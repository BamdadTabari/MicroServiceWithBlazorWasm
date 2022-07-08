using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Roles
{
    public class RolePermissionModel
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }

        public PermissionModel Permission { get; set; }
        public RoleModel Role { get; set; }
        public UserModel Creator { get; set; }
    }
}
