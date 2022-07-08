using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Mappers.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Queries.Weblog;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog
{
    public class GetWeblogPostByIdHandler : IRequestHandler<GetWeblogPostByIdQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetWeblogPostByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetWeblogPostByIdQuery request, CancellationToken cancellationToken)
        {
            // Get
            var entity = await _unitOfWork.WeblogPost.GetWeblogPostByIdAsync(request.WeblogPostId);

            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostErrors.PostNotFoundError);

            // Mapping
            var model = entity.MapToWeblogPostModel();

            return new OperationResult(OperationResultStatus.Ok, value: model);
        }
    }
}
