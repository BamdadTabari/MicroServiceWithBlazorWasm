using Illegible_Cms_V2.Server.Application.Interfaces;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Behaviors.Common;

public class CommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, OperationResult> where TRequest : MediatR.IRequest<OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CommitBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<OperationResult> next)
    {
        var operation = await next();

        if (operation.IsPersistAble)
            _ = await _unitOfWork.CommitAsync();

        return operation;
    }
}