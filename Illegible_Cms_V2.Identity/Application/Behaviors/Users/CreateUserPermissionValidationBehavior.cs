﻿using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Application.Validators.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Behaviors.Users;

public class CreateUserPermissionValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<CreateUserPermissionCommand, OperationResult>
{
    public async Task<OperationResult> Handle(CreateUserPermissionCommand request,
        CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult> next)
    {
        var validation = new CreateUserPermissionCommandValidator().Validate(request);
        if (!validation.IsValid)
            return new OperationResult(OperationResultStatus.Invalidated, value: validation.GetFirstErrorState());

        return await next();
    }
}