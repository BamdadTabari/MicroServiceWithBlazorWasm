using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity;
using MassTransit;
using System.Security.Claims;

namespace Illegible_Cms_V2.Gateway.Infrastructure;

public class AuthorizationHelper
{
    public static async Task AddPermissionClaimsAsync(HttpContext ctx)
    {
        // Getting request client service
        var requestClient = ctx.RequestServices.GetService<IRequestClient<GetUserBusRequest>>();

        // Getting user
        var userId = ctx.User.FindFirstValue(ClaimTypes.NameIdentifier).Decode();

        var username = ctx.User.FindFirstValue(ClaimTypes.Name);

        if (userId > 0)
        {
            // Getting profile
            var busModel = (await requestClient
                .GetResponse<GetUserBusResponse>(new { UserId = userId })).Message;

            // Creating permissions claims
            var permissionClaims = busModel.User.Permissions.Where(permission => permission != null)
                .Select(permission => new Claim("Permission", permission.Value));

            ctx.User.AddIdentity(new ClaimsIdentity(permissionClaims));

            ctx.User = new ClaimsPrincipal(new ClaimsIdentity(ctx.User.Claims, "local"));
        }
    }
}

