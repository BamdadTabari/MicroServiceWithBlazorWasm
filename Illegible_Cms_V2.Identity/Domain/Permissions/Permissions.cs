using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Domain.Permissions
{
    public class Permission : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }
        #region Navigations

        public User Creator { get; set; }
        public ICollection<RolePermission> Roles { get; set; }

        #endregion
    }
}
