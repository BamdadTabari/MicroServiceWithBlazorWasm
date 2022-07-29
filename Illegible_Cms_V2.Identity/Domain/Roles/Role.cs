using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Domain.Roles;

public class Role : IEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }

    #region Management

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    #endregion

    #region Navigations

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RolePermission> RolePermission { get; set; }

    #endregion
}