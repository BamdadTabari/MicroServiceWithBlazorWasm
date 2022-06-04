using Illegible_Cms_V2.Shared.BasicShared.Models;
using Microsoft.AspNetCore.Http;

namespace Illegible_Cms_V2.Shared.BasicShared.Extension;

public static class HttpRequestExtension
{
    private static int GetUserId(this HttpRequest request)
    {
        //var eid = JwtHelper.GetPayload(request.GetAuthToken())?
        //    .SingleOrDefault(x => x.Key == "nameid").Value;
        //return eid?.ToString().Decode() ?? 0;
        return 0;
    }

    private static string GetIpAddress(this HttpRequest request)
    {
        return request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
    }

    public static RequestInfo GetRequestInfo(this HttpRequest request)
    {
        return new RequestInfo
        {
            UserId = request.GetUserId(),
            IpAddress = request.GetIpAddress()
        };
    }
}