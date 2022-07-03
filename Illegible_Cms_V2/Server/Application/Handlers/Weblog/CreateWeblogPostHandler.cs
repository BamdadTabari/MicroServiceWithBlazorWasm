using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog;
using Illegible_Cms_V2.Server.Application.Specifications.Weblog;
using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog
{
    public class CreateWeblogPostHandler : IRequestHandler<CreateWeblogPostCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWeblogPostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> Handle(CreateWeblogPostCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.WeblogPost
                .ExistsAsync(new DuplicateWeblogPostSpecification(request.Title).ToExpression());

            if (!isExist)
                return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostErrors.DuplicatePostTitleError);

            var entity = new WeblogPost()
            {
                Summery = request.Summery,
                Title = request.Title,
                TextContent = request.TextContent
            };
            _unitOfWork.WeblogPost.Add(entity);
            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}
