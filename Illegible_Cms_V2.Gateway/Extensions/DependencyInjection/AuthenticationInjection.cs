using Illegible_Cms_V2.Gateway.Configurations;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Illegible_Cms_V2.Gateway.Extensions.DependencyInjection;  

public static class AuthenticationInjection
{
    public static IServiceCollection AddConfiguredAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Getting jwt config
        var jwtConfig = configuration.GetSection(SecurityTokenConfig.Key).Get<SecurityTokenConfig>();

        // Jwt Authentication
        services
            .AddAuthentication()
            .AddJwtBearer("Bearer", x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtConfig.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtConfig.AccessTokenSecretKey))
                };
            });

        return services;
    }
}

