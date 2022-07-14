using Illegible_Cms_V2.Identity.Domain.Permissions;

namespace Illegible_Cms_V2.Identity.Domain.Roles
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #region Management

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        #endregion

        #region Navigations

        public Permission Permission { get; set; }
        public Role Role { get; set; }

        #endregion
    }
}
