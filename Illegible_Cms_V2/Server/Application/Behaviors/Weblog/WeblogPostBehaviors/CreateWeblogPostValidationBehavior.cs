using Illegible_Cms_V2.Server.Application.Helpers.Common;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostValidators;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Behaviors.Weblog.WeblogPostBehaviors
{
    public class CreateWeblogPostValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<CreateWeblogPostCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(CreateWeblogPostCommand request,
           CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            var validation = new CreateWeblogPostCammandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

            return await next();
        }
    }
}
