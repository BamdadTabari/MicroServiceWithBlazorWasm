using Illegible_Cms_V2.Server.Application.Errors.Weblog;
using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Handlers.Weblog.WeblogPostHandlers;

public class UpdateWeblogPostCategoryHandler : IRequestHandler<UpdateWeblogPostCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateWeblogPostCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(UpdateWeblogPostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.WeblogPost.GetWeblogPostByIdAsync(request.Id);

        if (entity == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: WeblogPostErrors.PostNotFoundError);

        entity.Title = request.Title;
        entity.Summery = request.Summery;
        entity.TextContent = request.TextContent;

        _unitOfWork.WeblogPost.Update(entity);

        return new OperationResult(OperationResultStatus.Ok, value: entity);
    }
}