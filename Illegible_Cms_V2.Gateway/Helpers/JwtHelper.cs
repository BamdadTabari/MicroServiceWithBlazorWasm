using Illegible_Cms_V2.Gateway.Configurations;
using System.IdentityModel.Tokens.Jwt;

namespace Illegible_Cms_V2.Gateway.Helpers;

public static class JwtHelper
{
    public static SecurityTokenConfig Config;

    public static bool Validate(string token)
    {
        if (string.IsNullOrEmpty(token))
            return false;

        var isValid = true;

        // Valid Token Format 
        if (!new JwtSecurityTokenHandler().CanReadToken(token))
            return false;

        var payload = new JwtSecurityTokenHandler().ReadJwtToken(token)?.Payload;

        // Validation rules
        if (payload == null)
            return false;

        if (payload.Iss != Config.Issuer)
            isValid = false;

        if (!payload.Aud.Contains(Config.Audience))
            isValid = false;

        if (payload.ValidTo.Add(Config.RefreshTokenLifetime) < DateTime.UtcNow)
            isValid = false;

        return isValid;
    }

    public static JwtPayload GetPayload(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;
        return !Validate(token) ? null : new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
    }

    public static string GetUsername(string token)
    {
        var payload = GetPayload(token);
        return payload.Claims.SingleOrDefault(x => x.Type == "unique_name")?.Value;
    }
}

