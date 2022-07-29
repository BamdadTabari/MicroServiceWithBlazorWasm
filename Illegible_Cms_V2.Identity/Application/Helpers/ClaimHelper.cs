using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Domain.Claims;

namespace Illegible_Cms_V2.Identity.Application.Helpers;

public static class ClaimHelper
{
    public static Claim CreateClaim(CreateUserPermissionCommand command) => new Claim
    {
        Value = command.PermissionId.ToString(),
        Type = ClaimType.Permission,
        UserId = command.UserId,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
    };

}