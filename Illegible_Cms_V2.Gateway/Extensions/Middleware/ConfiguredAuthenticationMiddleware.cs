using Illegible_Cms_V2.Gateway.Helpers;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity;
using MassTransit;
using Ocelot.Middleware;
using System.Security.Claims;

namespace Illegible_Cms_V2.Gateway.Extensions.Middleware;


public static class ConfiguredAuthenticationMiddleware
{
    public static async Task UseConfiguredAuthentication(HttpContext ctx, Func<Task> next)
    {
        // Getting request client service
        var requestClient = ctx.RequestServices.GetService<IRequestClient<GetUserBusRequest>>();

        // Getting token
        var token = ctx.Request
            .Headers["Authorization"].FirstOrDefault()?.Substring("Bearer ".Length);

        if (string.IsNullOrEmpty(token))
        {
            ctx.Items.SetError(new UnauthenticatedError(""));
            ctx.Response.StatusCode = 401;
            return;
        }

        if (JwtHelper.Validate(token))
        {
            // Get Payload
            var payload = JwtHelper.GetPayload(token);
            var sub = payload.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var unique_name = payload.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value;
            var c_hash = payload.Claims.FirstOrDefault(x => x.Type == "c_hash")?.Value;

            // Getting profile
            var busModel = (await requestClient
                .GetResponse<GetUserBusResponse>(new { UserId = sub.Decode() })).Message;

            // Check SecurityStamp
            if (busModel.User.SecurityStamp != c_hash)
            {
                ctx.Items.SetError(new UnauthenticatedError(""));
                ctx.Response.StatusCode = 401;
                return;
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, sub),
                new(ClaimTypes.Name, unique_name)
            };

            ctx.User.AddIdentity(new ClaimsIdentity(claims));
            ctx.User = new ClaimsPrincipal(new ClaimsIdentity(ctx.User.Claims, "local"));
        }
        else if (!string.IsNullOrEmpty(token))
        {
            ctx.Items.SetError(new UnauthenticatedError(""));
            ctx.Response.StatusCode = 401;
            return;
        }

        await next.Invoke();
    }
}