using Illegible_Cms_V2.Identity.Application.Models.Commands.Auth;
using Illegible_Cms_V2.Identity.Application.Validators.Auth;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Behaviors.Auth
{
    public class LoginCommandValidationBehavior : IPipelineBehavior<LoginCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(LoginCommand request,
            CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            // Validation
            var validation = new LoginCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.Errors[0].CustomState);
            
            return await next();
        }
    }
}
