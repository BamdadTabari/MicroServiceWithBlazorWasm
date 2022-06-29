using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.BasicShared.Models;
using Illegible_Cms_V2.Shared.Infrastructure.Operations;
using MediatR;
using System.Security.Claims;

namespace Illegible_Cms_V2.Identity.Application.Models.Commands.Users
{
    public class CreateUserCommand : IRequestInfo, IRequest<OperationResult>
    {
        public CreateUserCommand(RequestInfo requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserState State { get; set; }
        public int CreatorId { get; set; }
        public int UpdaterId { get; set; }

        public RequestInfo RequestInfo { get; private set; }
    }
}
