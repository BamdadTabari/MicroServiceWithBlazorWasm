using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Auth;

public class GetUserProfileQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUserProfileQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int UserId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}