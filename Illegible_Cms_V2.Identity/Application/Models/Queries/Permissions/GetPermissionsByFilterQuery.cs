using Illegible_Cms_V2.Identity.Application.Models.Filters.Permissions;
using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Permissions
{
    public class GetPermissionsByFilterQuery : IRequestInfo, IRequest<OperationResult>
    {
        public GetPermissionsByFilterQuery(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public PermissionFilter Filter { get; set; }
        public RequestInfo RequestInfo { get; private set; }
    }
}
