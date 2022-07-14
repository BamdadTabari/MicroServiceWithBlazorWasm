using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Application.Validators.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Behaviors.Roles
{
    public class CreateRoleValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<CreateRoleCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(CreateRoleCommand request,
            CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            var validation = new CreateRoleCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

            return await next();
        }
    }
}
