using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Application.Validators.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Behaviors.Users
{
    public class DeleteUserPermissionValidationBehavior<TRequest, TResponse>
            : IPipelineBehavior<DeleteUserPermissionCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(DeleteUserPermissionCommand request,
            CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            var validation = new DeleteUserPermissionCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

            return await next();
        }
    }
}