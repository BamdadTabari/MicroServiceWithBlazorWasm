using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;

public class UpdateRoleCommand : IRequestInfo, IRequest<OperationResult>
{
    public UpdateRoleCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public int RoleId { get; set; }
    public string Title { get; set; }
    public IList<int> PermissionIds { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}