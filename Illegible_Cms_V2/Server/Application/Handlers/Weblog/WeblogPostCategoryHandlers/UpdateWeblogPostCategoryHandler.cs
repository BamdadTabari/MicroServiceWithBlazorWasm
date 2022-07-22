using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostCategoryHandlers
{
    public class UpdateWeblogPostCategoryHandler : IRequestHandler<UpdateWeblogPostCategoryCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateWeblogPostCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(UpdateWeblogPostCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.WeblogPostCategory.GetWeblogPostCategoryByIdAsync(request.Id);

            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostCategoryErrors.PostCategoryNotFoundError);

            entity.CategoryTitle = request.CategoryTitle;
            entity.CategoryIcon = request.CategoryIcon;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdaterId = request.RequestInfo.UserId;

            _unitOfWork.WeblogPostCategory.Update(entity);

            return new OperationResult(OperationResultStatus.Ok, value: entity);
        }
    }
}

