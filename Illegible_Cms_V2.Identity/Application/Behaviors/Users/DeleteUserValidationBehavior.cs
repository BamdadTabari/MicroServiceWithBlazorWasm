using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Application.Validators.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Behaviors.Users
{
    public class DeleteUserValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<DeleteUserCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            var validation = new DeleteUserCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

            return await next();
        }
    }
}