using Illegible_Cms_V2.Identity.Application.Models.Filters.Users;
using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Users
{
    public class GetUsersByFilterQuery : IRequestInfo, IRequest<OperationResult>
    {
        public GetUsersByFilterQuery(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public UserFilter Filter { get; set; }
        public RequestInfo RequestInfo { get; private set; }
    }
}
