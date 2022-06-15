using Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Roles
{
    public class GetRolesByFilterQuery : IRequestInfo, IRequest<OperationResult>
    {
        public GetRolesByFilterQuery(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public RoleFilter Filter { get; set; }
        public RequestInfo RequestInfo { get; private set; }
    }
}
