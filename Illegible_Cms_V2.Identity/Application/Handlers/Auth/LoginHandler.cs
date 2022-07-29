using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Auth;
using Illegible_Cms_V2.Identity.Application.Models.Results.Auth;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Auth;

internal class LoginHandler : IRequestHandler<LoginCommand, OperationResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByUsernameAsync(request.UserName);

        if (user == null)
            return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

        // Lockout check
        if (!user.CanLogin())
            return new OperationResult(OperationResultStatus.UnProcessable, value: AuthErrors.InvalidLoginError);

        // Login check via password
        var isLogin = PasswordHasher.Check(user.PasswordHash, request.Password);

        // Lockout history
        if (!isLogin)
        {
            user.TryToLockout();
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();
            return new OperationResult(OperationResultStatus.UnProcessable, value: AuthErrors.InvalidLoginError);
        }

        /* Here user is authenticated */
        // Other updates
        if (user.State == UserState.InActive)
            user.Activate();

        user.LastLoginDate = DateTime.UtcNow;
        user.ResetLockoutHistory();
        _unitOfWork.Users.Update(user);


        var result = new LoginResult
        {
            UserName = user.Username,
            AccessToken = user.CreateJwtAccessToken(),
            RefreshToken = user.CreateJwtRefreshToken()
        };

        return new OperationResult(OperationResultStatus.Ok, value: result);
    }
}