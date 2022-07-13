using AutoMapper;
using Illegible_Cms_V2.Identity.Application.Interfaces;
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
        private readonly IMapper _mapper;

        public GetPermissionsByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(GetPermissionsByFilterQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Permissions.GetPermissionsByFilterAsync(request.Filter);

            var models = _mapper.Map<List<PermissionModel>>(entities);

            var result = new PaginatedList<PermissionModel>
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