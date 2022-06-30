using MediatR;
using Illegible_Cms_V2.Server.Application.Behaviors.Common;
namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection
{
    public static class MediatRInjection
    {
        public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
        {
            // Generic behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

            return services;
        }
    }
}
