using Illegible_Cms_V2.Shared.BasicShared.Configurations;
using Illegible_Cms_V2.Shared.SharedServices.ServiceBus.Rpc.Identity;
using MassTransit;

namespace Illegible_Cms_V2.Gateway.Extensions.DependencyInjection;

public static class MassTransitInjection
{
    public static IServiceCollection AddConfiguredMassTransit(this IServiceCollection services,
        IConfiguration configuration)
    {
        var rabbitConfig = configuration.GetSection(RabbitMQConfig.Key).Get<RabbitMQConfig>();
        //  services.AddHealthChecks();
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            x.AddRequestClient<GetUserBusRequest>();

            x.UsingRabbitMq((context, config) =>
            {
                // config.UseHealthCheck(context);
                config.Host(new Uri(rabbitConfig.Host), h =>
                    {
                        h.Username(rabbitConfig.Username);
                        h.Password(rabbitConfig.Password);
                    }
                );
                config.ConfigureEndpoints(context);
            });
        });

        //services.AddMassTransitHostedService();

        return services;
    }
}