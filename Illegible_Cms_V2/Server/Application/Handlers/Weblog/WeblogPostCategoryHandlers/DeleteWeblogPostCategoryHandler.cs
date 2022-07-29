using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostCategoryHandlers;

public class DeleteWeblogPostCategoryHandler : IRequestHandler<DeleteWeblogPostCategoryCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWeblogPostCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult> Handle(DeleteWeblogPostCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WeblogPostCategory.GetWeblogPostCategoryByIdAsync(request.Id);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostCategoryErrors.PostCategoryNotFoundError);

        _unitOfWork.WeblogPostCategory.Remove(entity);
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}