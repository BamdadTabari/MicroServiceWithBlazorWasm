using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    public class DeleteUserPermissionHandler : IRequestHandler<DeleteUserPermissionCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
        {
            // Get
            var entity = await _unitOfWork.Claims.GetClaimByIdAsync(request.ClaimId);

            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: PermissionErrors.ClaimNotFoundError);

            // Soft Delete
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            entity.UpdaterId = request.RequestInfo.UserId;
            _unitOfWork.Claims.Update(entity);

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}