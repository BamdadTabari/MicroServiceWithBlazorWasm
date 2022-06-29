using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;

namespace Illegible_Cms_V2.Identity.Application.Models.Commands.Auth
{
    public class LoginCommand: IRequestInfo, IRequest<OperationResult>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RequestInfo RequestInfo { get; private set; }
    }
}
