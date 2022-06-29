
using Illegible_Cms_V2.Identity.ServiceBus.Consumers;
using Illegible_Cms_V2.Shared.BasicShared.Configurations;
using MassTransit;

namespace Illegible_Cms_V2.Identity.Api.Extensions.DependencyInjection
{
    public static class MassTransitInjection
    {
        public static IServiceCollection AddConfiguredMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitConfig = configuration.GetSection(RabbitMQConfig.Key).Get<RabbitMQConfig>();
            
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddConsumer<GetUserBusRequestConsumer>();

                x.UsingRabbitMq((context, config) =>
                {
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
}
