using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Mappers;
using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Roles
{
    public class GetRolesByFilterHandler : IRequestHandler<GetRolesByFilterQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRolesByFilterHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetRolesByFilterQuery request, CancellationToken cancellationToken)
        {
            // Get
            request.Filter.Include = new RoleIncludes { Permission = true };

            var entities = await _unitOfWork.Roles.GetRolesByFilterAsync(request.Filter);

            // Mapper
            var models = entities.MapToRoleModels();

            var result = new PaginatedList<RoleModel>
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
