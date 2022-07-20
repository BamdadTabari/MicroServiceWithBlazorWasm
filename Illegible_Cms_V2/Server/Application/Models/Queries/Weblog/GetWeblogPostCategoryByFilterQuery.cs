using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Queries.Weblog
{
    public class GetWeblogPostCategoryByFilterQuery : IRequestInfo, IRequest<OperationResult>
    {
        public GetWeblogPostCategoryByFilterQuery(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public WeblogPostCategoryFilter Filter { get; set; }
        public RequestInfo RequestInfo { get; private set; }
    }
}
