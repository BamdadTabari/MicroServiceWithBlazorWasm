using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Commands.Weblog
{
    public class CreateWeblogPostCommand : IRequestInfo, IRequest<OperationResult>
    {
        public CreateWeblogPostCommand(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public string Title { get; set; }
        public string Summery { get; set; }
        public string TextContent { get; set; }
        public RequestInfo RequestInfo { get; private set; }
    }
}
