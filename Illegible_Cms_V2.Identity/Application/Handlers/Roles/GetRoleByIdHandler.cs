using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Mappers;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Roles
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoleByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            // Get
            var entity = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId);

            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: RoleErrors.RoleNotFoundError);

            // Mapping
            var model = entity.MapToRoleModel();

            return new OperationResult(OperationResultStatus.Ok, value: model);
        }
    }
}