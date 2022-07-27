using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;
using Illegible_Cms_V2.Server.Application.Specifications.Weblog;
using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostCategoryHandlers
{
    public class CreateWeblogPostCategoryHandler : IRequestHandler<CreateWeblogPostCategoryCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWeblogPostCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult> Handle(CreateWeblogPostCategoryCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _unitOfWork.WeblogPostCategory
                .ExistsAsync(new DuplicateWeblogPostCategorySpecificstion(request.CategoryTitle).ToExpression());

            if (!isExist)
                return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostCategoryErrors.DuplicatePostCategoryTitleError);

            var entity = new WeblogPostCategory()
            {
                CategoryTitle = request.CategoryTitle,
                CategoryIcon = request.CategoryIcon,
                CreatedAt = DateTime.Now,
                CreatorId = request.RequestInfo.UserId,
            };
            _unitOfWork.WeblogPostCategory.Add(entity);
            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
        }
    }
}
