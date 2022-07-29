using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Auth;

public class RefreshTokenQuery : IRequestInfo, IRequest<OperationResult>
{
    public RequestInfo RequestInfo { get; private set; }
    public RefreshTokenQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public string RefreshToken { get; set; }
}