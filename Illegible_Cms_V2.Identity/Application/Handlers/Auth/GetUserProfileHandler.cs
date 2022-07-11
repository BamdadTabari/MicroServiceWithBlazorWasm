using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Mappers;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Auth;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Auth
{
    internal class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
            if (user == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

            var model = user.MapToUserModel();

            return new OperationResult(OperationResultStatus.Ok, value: model);
        }
    }
}
