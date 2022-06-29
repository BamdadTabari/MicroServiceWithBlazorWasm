using System.Reflection;
using Illegible_Cms_V2.Identity.Application.Behaviors.Common;
using Illegible_Cms_V2.Identity.Application.Behaviors.Roles;
using Illegible_Cms_V2.Identity.Application.Behaviors.Users;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Api.Extensions.DependencyInjection
{
    public static class MediatRInjection
    {
        public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
        {
            // Handlers
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

            // Generic behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

            // Validation behaviors
            // Users
            services.AddTransient(typeof(IPipelineBehavior<CreateUserCommand, OperationResult>),
                typeof(CreateUserValidationBehavior<CreateUserCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<UpdateUserCommand, OperationResult>),
                typeof(UpdateUserValidationBehavior<UpdateUserCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<DeleteUserCommand, OperationResult>),
                typeof(DeleteUserValidationBehavior<DeleteUserCommand, OperationResult>));

            // User Role
            services.AddTransient(typeof(IPipelineBehavior<UpdateUserRolesCommand, OperationResult>),
                typeof(UpdateUserRolesValidationBehavior<UpdateUserRolesCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<CreateUserPermissionCommand, OperationResult>),
                typeof(CreateUserPermissionValidationBehavior<CreateUserPermissionCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<DeleteUserPermissionCommand, OperationResult>),
                typeof(DeleteUserPermissionValidationBehavior<DeleteUserPermissionCommand, OperationResult>));

            // Role 
            services.AddTransient(typeof(IPipelineBehavior<CreateRoleCommand, OperationResult>),
                typeof(CreateRoleValidationBehavior<CreateRoleCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<UpdateRoleCommand, OperationResult>),
               typeof(UpdateRoleValidationBehavior<UpdateRoleCommand, OperationResult>));
            services.AddTransient(typeof(IPipelineBehavior<DeleteRoleCommand, OperationResult>),
                typeof(DeleteRoleValidationBehavior<DeleteRoleCommand, OperationResult>));

            return services;
        }
    }
}
