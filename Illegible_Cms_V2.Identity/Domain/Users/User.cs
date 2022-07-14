using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Domain.Users
{
    public class User : IEntity
    {
        #region Identity

        public int Id { get; set; }
        public string Username { get; set; }

        public string Mobile { get; set; }
        public bool IsMobileConfirmed { get; set; }

        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }

        #endregion

        #region Login

        public string PasswordHash { get; set; }
        public DateTime? LastPasswordChangeTime { get; set; }

        public int FailedLoginCount { get; set; }
        public DateTime? LockoutEndTime { get; set; }

        public DateTime? LastLoginDate { get; set; }

        #endregion

        #region Profile
        public UserState State { get; set; }

        #endregion

        #region Management

        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLockedOut { get; set; }
        #endregion

        #region Navigations

        public ICollection<Claim> Claims { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        #endregion
    }
}
