using Illegible_Cms_V2.Identity.Domain.Permissions;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Domain.Roles
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #region Management

        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }

        #endregion

        #region Navigations

        public Permission Permission { get; set; }
        public Role Role { get; set; }
        public User Creator { get; set; }

        #endregion
    }
}
