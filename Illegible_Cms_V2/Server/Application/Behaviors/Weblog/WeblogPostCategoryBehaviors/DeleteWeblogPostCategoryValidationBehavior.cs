﻿using Illegible_Cms_V2.Server.Application.Helpers.Common;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;
using Illegible_Cms_V2.Server.Application.Validators.Weblog;
using Illegible_Cms_V2.Server.Application.Validators.Weblog.WeblogPostCategoryValidators;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Behaviors.Weblog.WeblogPostCategoryBehaviors
{
    public class DeleteWeblogPostCategoryValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<DeleteWeblogPostCategoryCommand, OperationResult>
    {
        public async Task<OperationResult> Handle(DeleteWeblogPostCategoryCommand request,
           CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
        {
            var validation = new DeleteWeblogPostCategoryCommandValidator().Validate(request);
            if (!validation.IsValid)
                return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

            return await next();
        }
    }
}
