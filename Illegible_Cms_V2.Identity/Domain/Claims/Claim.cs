using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.BasicShared.Models;

namespace Illegible_Cms_V2.Identity.Domain.Claims;

public class Claim : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ClaimType Type { get; set; }
    public string Value { get; set; }

    #region Management
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    #endregion

    #region Navigations

    public User User { get; set; }

    #endregion
}