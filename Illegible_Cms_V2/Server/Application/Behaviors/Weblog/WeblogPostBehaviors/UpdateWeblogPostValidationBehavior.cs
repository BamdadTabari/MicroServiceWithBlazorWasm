using Illegible_Cms_V2.Server.Application.Helpers.Common;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostValidators;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Behaviors.Weblog.WeblogPostBehaviors
{
    public class UpdateWeblogPostValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<UpdateWeblogPostCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(UpdateWeblogPostCommand request,
           CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            var validation = new UpdateWeblogPostCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

            return await next();
        }
    }
}
