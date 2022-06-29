using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Queries.Users;

public class GetUserByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetUserByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public GetUserByIdQuery()
    {
    }

    public int UserId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}