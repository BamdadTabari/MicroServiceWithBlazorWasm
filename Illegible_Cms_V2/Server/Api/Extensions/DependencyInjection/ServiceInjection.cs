﻿namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
