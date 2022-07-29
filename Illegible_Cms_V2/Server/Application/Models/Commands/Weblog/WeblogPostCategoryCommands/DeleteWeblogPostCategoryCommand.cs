using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;

public class DeleteWeblogPostCategoryCommand : IRequestInfo, IRequest<OperationResult>
{
    public DeleteWeblogPostCategoryCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }
    public RequestInfo RequestInfo { get; set; }
}