using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Application.Specifications.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Roles
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.Roles
                .ExistsAsync(new DuplicateRoleSpecification(request.Title).ToExpression());

            if (isExist)
                return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.DuplicateTitleError);

            var entity = RoleHelper.CreateRole(request);

            _unitOfWork.Roles.Add(entity);

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}