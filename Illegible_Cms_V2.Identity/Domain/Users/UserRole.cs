using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Domain.Users
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        #region Management

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion

        #region Navigations

        public User User { get; set; }
        public Role Role { get; set; }

        #endregion
    }
}
