using Illegible_Cms_V2.Identity.Application.Errors;
using Illegible_Cms_V2.Identity.Application.Interfaces;
using Illegible_Cms_V2.Identity.Application.Mappers;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Handlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            
            var entity = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
            if (entity == null)
                return new OperationResult(OperationResultStatus.UnProcessable, value: UserErrors.UserNotFoundError);

            
            var model = entity.MapToUserModel();

            return new OperationResult(OperationResultStatus.Ok, value: model);
        }
    }
}