using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Roles
{
    public class GetRoleByIdQuery : IRequestInfo, IRequest<OperationResult>
    {
        public GetRoleByIdQuery(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public int RoleId { get; set; }
        public RequestInfo RequestInfo { get; private set; }
    }
}
