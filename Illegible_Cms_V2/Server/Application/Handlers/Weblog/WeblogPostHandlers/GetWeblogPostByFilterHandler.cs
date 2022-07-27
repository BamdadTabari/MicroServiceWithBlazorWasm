using AutoMapper;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Queries.Weblog.WeblogPostQueries;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostHandlers
{
    public class GetWeblogPostCategoryByFilterHandler : IRequestHandler<GetWeblogPostByFilterQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetWeblogPostCategoryByFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(GetWeblogPostByFilterQuery request, CancellationToken cancellationToken)
        {

            var entities = await _unitOfWork.WeblogPost.GetWeblogPostsByFilterAsync(request.Filter);

            var models = _mapper.Map<List<WeblogPostModel>>(entities);

            var result = new PaginatedList<WeblogPostModel>
            {
                Page = request.Filter.Page,
                PageSize = request.Filter.PageSize,
                Data = models,
                TotalCount = models.Count
            };

            return new OperationResult(OperationResultStatus.Ok, value: result);
        }
    }
}
