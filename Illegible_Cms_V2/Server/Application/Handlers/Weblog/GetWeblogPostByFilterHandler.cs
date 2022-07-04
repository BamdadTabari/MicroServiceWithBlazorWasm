using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Mappers.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Queries.Weblog;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog
{
    public class GetWeblogPostByFilterHandler : IRequestHandler<GetWeblogPostByFilterQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWeblogPostByFilterHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetWeblogPostByFilterQuery request, CancellationToken cancellationToken)
        {

            var entities = await _unitOfWork.WeblogPost.GetWeblogPostsByFilterAsync(request.Filter);

            var models = entities.MapToWeblogPostModels();

            var result = new PaginatedList<WeblogPostModel>
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
