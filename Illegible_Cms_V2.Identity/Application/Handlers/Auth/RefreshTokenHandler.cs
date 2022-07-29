using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Auth;
using Illegible_Cms_V2.Identity.Application.Models.Results.Auth;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Auth;

internal class RefreshTokenHandler : IRequestHandler<RefreshTokenQuery, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var username = JwtHelper.GetUsername(request.RefreshToken);

        var user = await _unitOfWork.Users.GetUserByUsernameAsync(username);
        if (user == null)
            return new OperationResult(OperationResultStatus.Unauthorized, value: UserErrors.UserNotFoundError);

        // Lockout check
        if (!user.CanLogin())
            return new OperationResult(OperationResultStatus.Unauthorized, value: AuthErrors.InvalidLoginError);

        var result = new TokenResult
        {
            AccessToken = user.CreateJwtAccessToken(),
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}