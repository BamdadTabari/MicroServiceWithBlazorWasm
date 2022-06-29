using Illegible_Cms_V2.Identity.Api.Models.Requests.Auth;
using Illegible_Cms_V2.Identity.Api.ResultFilters.Auth;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Auth;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Auth;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Identity.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Auth + "login")]
        [LoginResultFilter]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var operation = await _mediator.Send(new LoginCommand
            {
                UserName = request.Username,
                Password = request.Password,
            });

            return this.ReturnResponse(operation);
        }

        [HttpGet(Routes.Auth + "token")]
        [TokenResultFilter]
        public async Task<IActionResult> GetAccessToken([FromHeader] string refresh)
        {
            var operation = await _mediator.Send(new RefreshTokenQuery(Request.GetRequestInfo())
            {
                RefreshToken = refresh
            });

            return this.ReturnResponse(operation);
        }

        [HttpGet(Routes.Auth + "profile")]
        [GetProfileResultFilter]
        public async Task<IActionResult> Profile()
        {
            // Operation
            var operation = await _mediator.Send(new GetUserProfileQuery(Request.GetRequestInfo()));

            return this.ReturnResponse(operation);
        }
    }
}
