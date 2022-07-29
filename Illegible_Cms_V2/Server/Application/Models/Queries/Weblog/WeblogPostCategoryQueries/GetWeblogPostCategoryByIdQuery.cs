using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Queries.Weblog.WeblogPostCategoryQueries;

public class GetWeblogPostCategoryByIdQuery : IRequestInfo, IRequest<OperationResult>
{
    public GetWeblogPostCategoryByIdQuery(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int Id { get; set; }
    public RequestInfo RequestInfo { get; private set; }
}