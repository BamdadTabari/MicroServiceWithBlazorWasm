using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Commands.Users
{
    public class CreateUserPermissionCommand : IRequestInfo, IRequest<OperationResult>
    {
        public CreateUserPermissionCommand(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public RequestInfo RequestInfo { get; private set; }
    }
}
