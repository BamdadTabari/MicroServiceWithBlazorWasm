using Illegible_Cms_V2.Identity.Api.Models.Requests.Users;
using Illegible_Cms_V2.Identity.Api.ResultFilters.Users;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Users;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Identity.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region User

        [HttpPost(Routes.Users)]
        [CreateUserResultFilter]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var operation = await _mediator.Send(new CreateUserCommand(Request.GetRequestInfo())
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Mobile = request.Mobile,
                State = Domain.Users.UserState.Suspended
            });

            return this.ReturnResponse(operation);
        }

        [HttpPut(Routes.Users + "{ueid}")]
        [UpdateUserResultFilter]
        public async Task<IActionResult> UpdateUser([FromRoute] string ueid, [FromBody] UpdateUserRequest request)
        {
            var userId = ueid.Decode();

            var operation = await _mediator.Send(new UpdateUserCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                Mobile = request.Mobile,
            });

            return this.ReturnResponse(operation);
        }

        [HttpGet(Routes.Users + "{ueid}")]
        [GetUserByIdResultFilter]
        public async Task<IActionResult> GetUserById([FromRoute] string ueid)
        {
            var userId = ueid.Decode();

            var operation = await _mediator.Send(new GetUserByIdQuery(Request.GetRequestInfo())
            {
                UserId = userId
            });

            return this.ReturnResponse(operation);
        }


        // Patch Password
        [HttpPatch(Routes.Users + "{ueid}/password")]
        [UpdateUserResultFilter]
        public async Task<IActionResult> UpdateUserPassword([FromRoute] string ueid, [FromBody] UpdateUserPasswordRequest request)
        {
            var userId = ueid.Decode();

            var operation = await _mediator.Send(new UpdateUserPasswordCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                NewPassword = request.NewPassword
            });

            return this.ReturnResponse(operation);
        }

        #endregion

        #region Role

        [HttpPatch(Routes.Users + "{ueid}/roles")]
        [UpdateUserRolesResultFilter]
        public async Task<IActionResult> UpdateUserRoles([FromRoute] string ueid, [FromBody] UpdateUserRolesRequest request)
        {
            var userId = ueid.Decode();
            var roleIds = request.RoleEids?.Select(x => x.Decode());

            var operation = await _mediator.Send(new UpdateUserRolesCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                RoleIds = roleIds
            });

            return this.ReturnResponse(operation);
        }

        #endregion

        #region Permission

        [HttpPost(Routes.Users + "{ueid}/permissions/{peid}")]
        [CreateUserPermissionResultFilter]
        public async Task<IActionResult> CreateUserPermission([FromRoute] string ueid, [FromRoute] string peid)
        {
            var userId = ueid.Decode();
            var permissionId = peid.Decode();

            var operation = await _mediator.Send(new CreateUserPermissionCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                PermissionId = permissionId
            });

            return this.ReturnResponse(operation);
        }

        [HttpDelete(Routes.Users + "permission/{ceid}")]
        [DeleteUserPermissionResultFilter]
        public async Task<IActionResult> DeleteUserPermission([FromRoute] string ceid)
        {
            var claimId = ceid.Decode();

            var operation = await _mediator.Send(new DeleteUserPermissionCommand(Request.GetRequestInfo())
            {
                ClaimId = claimId
            });

            return this.ReturnResponse(operation);
        }

        #endregion
    }
}
