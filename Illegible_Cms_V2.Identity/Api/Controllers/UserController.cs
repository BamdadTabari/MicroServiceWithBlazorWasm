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

        public UserController()
        {
        }


        // Get user by id
        [HttpGet(Routes.Users + "{ueid}")]
        [GetUserByIdResultFilter]
        public async Task<IActionResult> GetUserById([FromRoute] string ueid)
        {
            // Decode
            var userId = ueid.Decode();

            // Operation
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
            // Decode
            var userId = ueid.Decode();

            // Operation
            var operation = await _mediator.Send(new UpdateUserPasswordCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                NewPassword = request.NewPassword
            });

            return this.ReturnResponse(operation);
        }

        #region Role

        // Update Roles
        [HttpPatch(Routes.Users + "{ueid}/roles")]
        [UpdateUserRolesResultFilter]
        public async Task<IActionResult> UpdateUserRoles([FromRoute] string ueid, [FromBody] UpdateUserRolesRequest request)
        {
            // Decode
            var userId = ueid.Decode();
            var roleIds = request.RoleEids?.Select(x => x.Decode());

            // Operation
            var operation = await _mediator.Send(new UpdateUserRolesCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                RoleIds = roleIds
            });

            return this.ReturnResponse(operation);
        }

        #endregion

        #region Permission

        // Create User Permission
        [HttpPost(Routes.Users + "{ueid}/permissions/{peid}")]
        [CreateUserPermissionResultFilter]
        public async Task<IActionResult> CreateUserPermission([FromRoute] string ueid, [FromRoute] string peid)
        {
            // Decode
            var userId = ueid.Decode();
            var permissionId = peid.Decode();

            // Operation
            var operation = await _mediator.Send(new CreateUserPermissionCommand(Request.GetRequestInfo())
            {
                UserId = userId,
                PermissionId = permissionId
            });

            return this.ReturnResponse(operation);
        }

        // Delete User Permission
        [HttpDelete(Routes.Users + "permission/{ceid}")]
        [DeleteUserPermissionResultFilter]
        public async Task<IActionResult> DeleteUserPermission([FromRoute] string ceid)
        {
            // Decode
            var claimId = ceid.Decode();

            // Operation
            var operation = await _mediator.Send(new DeleteUserPermissionCommand(Request.GetRequestInfo())
            {
                ClaimId = claimId
            });

            return this.ReturnResponse(operation);
        }

        #endregion
    }
}
