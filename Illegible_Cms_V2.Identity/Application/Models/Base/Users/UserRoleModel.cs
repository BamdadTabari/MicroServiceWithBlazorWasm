using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;

namespace Illegible_Cms_V2.Identity.Application.Models.Base.Users;

public class UserRoleModel
{
    public int RoleId { get; set; }
    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserModel User { get; set; }
    public RoleModel Role { get; set; }
}