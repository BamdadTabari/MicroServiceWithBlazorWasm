using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Application.Specifications.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Roles
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

            if (role == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);

            var isExist = await _unitOfWork.Roles
                .ExistsAsync(new DuplicateRoleSpecification(request.Title).ToExpression());

            if (isExist && role.Title != request.Title)
                return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.DuplicateTitleError);

            // Update
            role.Title = request.Title;
            role.RolePermission = request.PermissionIds.Distinct()
                .Select(x => RoleHelper.CreateRolePermission(x, request.RequestInfo.UserId, request.RoleId)).ToList();

            role.UpdatedAt = DateTime.Now;

            _unitOfWork.Roles.Update(role);

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: role);
        }
    }
}