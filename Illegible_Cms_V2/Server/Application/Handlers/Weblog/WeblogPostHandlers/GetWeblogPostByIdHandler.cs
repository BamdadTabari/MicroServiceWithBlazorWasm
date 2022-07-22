using AutoMapper;
using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Queries.Weblog;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostHandlers
{
    public class GetWeblogPostCategoryByIdHandler : IRequestHandler<GetWeblogPostByIdQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetWeblogPostCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(GetWeblogPostByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.WeblogPost.GetWeblogPostByIdAsync(request.WeblogPostId);

            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostErrors.PostNotFoundError);

            var model = _mapper.Map<WeblogPostModel>(entity);

            return new OperationResult(OperationResultStatus.Ok, value: model);
        }
    }
}
