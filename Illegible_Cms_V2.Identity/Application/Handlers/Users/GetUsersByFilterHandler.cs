using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Mappers;
using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Users;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    public class GetUsersByFilterHandler : IRequestHandler<GetUsersByFilterQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersByFilterHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetUsersByFilterQuery request, CancellationToken cancellationToken)
        {
            // Get
            request.Filter.Include = new UserIncludes { Role = true };

            var entities = await _unitOfWork.Users.GetUsersByFilterAsync(request.Filter);

            // Mapper
            var models = entities.MapToUserModels();

            var result = new PaginatedList<UserModel>
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