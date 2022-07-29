using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostHandlers;

public class DeleteWeblogPostCategoryHandler : IRequestHandler<DeleteWeblogPostCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteWeblogPostCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<OperationResult> Handle(DeleteWeblogPostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WeblogPost.GetWeblogPostByIdAsync(request.Id);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostErrors.PostNotFoundError);

        _unitOfWork.WeblogPost.Remove(entity);
        return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: entity);
    }
}