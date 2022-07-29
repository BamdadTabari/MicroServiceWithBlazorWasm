using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Queries.Weblog.WeblogPostQueries;

public class GetWeblogPostByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int WeblogPostId { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}