using Illegible_Cms_V2.Server.Application.Behaviors.Common;
using Illegible_Cms_V2.Server.Application.Behaviors.Weblog.WeblogPostBehaviors;
using Illegible_Cms_V2.Server.Application.Behaviors.Weblog.WeblogPostCategoryBehaviors;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;
namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection
{
    public static class MediatRInjection
    {
        public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
        {
            // Generic behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

            #region weblog

            #region weblog post

            services.AddTransient(typeof(IPipelineBehavior<CreateWeblogPostCommand, OperationResult>),
             typeof(CreateWeblogPostValidationBehavior<CreateWeblogPostCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<UpdateWeblogPostCommand, OperationResult>),
                typeof(UpdateWeblogPostValidationBehavior<UpdateWeblogPostCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<DeleteWeblogPostCommand, OperationResult>),
                typeof(DeleteWeblogPostValidationBehavior<DeleteWeblogPostCommand, OperationResult>));

            #endregion

            #region weblog post category

            services.AddTransient(typeof(IPipelineBehavior<CreateWeblogPostCategoryCommand, OperationResult>),
             typeof(CreateWeblogPostCategoryValidationBehavior<CreateWeblogPostCategoryCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<UpdateWeblogPostCategoryCommand, OperationResult>),
                typeof(UpdateWeblogPostCategoryValidationBehavior<UpdateWeblogPostCategoryCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<DeleteWeblogPostCategoryCommand, OperationResult>),
                typeof(DeleteWeblogPostCategoryValidationBehavior<DeleteWeblogPostCategoryCommand, OperationResult>));

            #endregion

            #endregion
            
            return services;
        }
    }
}