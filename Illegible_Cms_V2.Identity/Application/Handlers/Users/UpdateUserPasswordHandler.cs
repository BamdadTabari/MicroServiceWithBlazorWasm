using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    public class UpdateUserPasswordHandler : IRequestHandler<UpdateUserPasswordCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserPasswordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            // Get
            var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
            if (user == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

            user.PasswordHash = new PasswordHasher().Hash(request.NewPassword);

            user.UpdaterId = request.RequestInfo.UserId;
            user.UpdatedAt = DateTime.Now;

            _unitOfWork.Users.Update(user);

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: user);
        }
    }
}
