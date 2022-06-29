using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Commands.Users
{
    public class UpdateUserRolesCommand : IRequestInfo, IRequest<OperationResult>
    {
        public UpdateUserRolesCommand(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public int UserId { get; set; }
        public IEnumerable<int> RoleIds { get; set; }

        public RequestInfo RequestInfo { get; private set; }
    }
}
