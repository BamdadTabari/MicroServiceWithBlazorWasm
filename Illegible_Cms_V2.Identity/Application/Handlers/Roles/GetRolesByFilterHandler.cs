using AutoMapper;
using Illegible_Cms_V2.Identity.Application.Interfaces;
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
        private readonly IMapper _mapper;

        public GetRolesByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(GetRolesByFilterQuery request, CancellationToken cancellationToken)
        {
            request.Filter.Include = new RoleIncludes { Permission = true };

            var entities = await _unitOfWork.Roles.GetRolesByFilterAsync(request.Filter);

            var models = _mapper.Map<List<RoleModel>>(entities);

            var result = new PaginatedList<RoleModel>
            {
                Page = request.Filter.Page,
                PageSize = request.Filter.PageSize,
                Data = models,
                TotalCount = models.Count()
            };

            return new OperationResult(OperationResultStatus.Ok, value: result);
        }
    }
}
