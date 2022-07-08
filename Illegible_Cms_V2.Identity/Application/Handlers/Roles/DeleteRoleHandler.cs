using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Roles
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);
            
            entity.UpdatedAt = DateTime.Now;
            _unitOfWork.Roles.Update(entity); ;

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}