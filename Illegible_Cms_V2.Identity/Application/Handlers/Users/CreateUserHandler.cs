﻿using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Application.Specifications.Claims;
using Illegible_Cms_V2.Identity.Application.Specifications.Users;
using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Checking same user name
            var isExist = await _unitOfWork.Users
                .ExistsAsync(new DuplicateUserSpecification(request.Username).ToExpression());

            if (!isExist)
                return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.DuplicateUsernameError);

            // Factory
            var entity = new User()
            {
                Username = request.Username,
                Mobile = request.Mobile,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                State = request.State,
                CreatorId = request.CreatorId,
                UpdaterId = request.UpdaterId
            };

            _unitOfWork.Users.Add(entity);    

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}
