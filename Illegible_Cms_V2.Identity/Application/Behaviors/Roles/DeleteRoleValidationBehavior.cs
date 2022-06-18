using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Application.Validators.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Behaviors.Roles
{
    public class DeleteRoleValidationBehavior
        : IPipelineBehavior<DeleteRoleCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(DeleteRoleCommand request,
            CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            // Validation
            var validation = new DeleteRoleCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value:validation.GetFirstErrorState());

            return await next();
        }
    }
}