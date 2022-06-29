using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Mappers;
using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Permissions;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Permissions
{
    public class GetPermissionsByFilterHandler : IRequestHandler<GetPermissionsByFilterQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionsByFilterHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetPermissionsByFilterQuery request, CancellationToken cancellationToken)
        {
            // Get
            var entities = await _unitOfWork.Permissions.GetPermissionsByFilterAsync(request.Filter);

            // Mapper
            var models = entities.MapToPermissionModels();

            var result = new PaginatedList<PermissionModel>
            {
                Page = request.Filter.Page,
                PageSize = request.Filter.PageSize,
                Data = models.ToList(),
                TotalCount = models.Count()
            };

            return new OperationResult(OperationResultStatus.Ok, value: result);
        }
    }
}