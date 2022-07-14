using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    internal class UpdateUserRolesHandler : IRequestHandler<UpdateUserRolesCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserRolesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);

            if (user == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

            if (user.UserRoles.Count == 0)
                return new OperationResult(OperationResultStatus.UnProcessable, value: AuthErrors.UnauthorizedRequestError);

            // Update
            if (request.RoleIds != null)
                user.UserRoles = request.RoleIds.Select(x => new UserRole
                {
                    UserId = request.UserId,
                    RoleId = x
                }).ToList();

            _unitOfWork.Users.Update(user);

            return new OperationResult(OperationResultStatus.Ok, isPersistAble: true, value: user);
        }
    }
}
