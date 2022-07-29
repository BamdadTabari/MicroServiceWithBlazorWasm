using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCommands;

public class DeleteWeblogPostCommand : IRequestInfo, IRequest<OperationResult>
{
    public RequestInfo RequestInfo { get; set; }

    public DeleteWeblogPostCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }
    public int Id { get; set; }
}