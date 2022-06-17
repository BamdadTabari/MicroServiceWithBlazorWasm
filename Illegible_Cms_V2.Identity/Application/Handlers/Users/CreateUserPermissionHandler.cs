using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Application.Specifications.Claims;
using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    public class CreateUserPermissionHandler : IRequestHandler<CreateUserPermissionCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(CreateUserPermissionCommand request, CancellationToken cancellationToken)
        {
            // Checking same Claim
            var isExist = await _unitOfWork.Claims
                .ExistsAsync(new DuplicateClaimSpecification(request.PermissionId, request.UserId, ClaimType.Permission).ToExpression());

            if (isExist)
                return new OperationResult(OperationResultStatus.UnProcessable, value: PermissionErrors.DuplicateClaimError);

            // Factory
            var entity = ClaimHelper.CreateClaim(request);

            _unitOfWork.Claims.Add(entity);

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}
