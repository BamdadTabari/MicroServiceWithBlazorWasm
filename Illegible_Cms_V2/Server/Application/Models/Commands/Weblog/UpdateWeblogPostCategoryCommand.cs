using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Commands.Weblog
{
    public class UpdateWeblogPostCategoryCommand : IRequestInfo, IRequest<OperationResult>
    {
        public UpdateWeblogPostCategoryCommand(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryIcon { get; set; }

        public RequestInfo RequestInfo { get; set; }
    }
}
