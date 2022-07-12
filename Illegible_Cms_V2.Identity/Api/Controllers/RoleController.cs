using Illegible_Cms_V2.Identity.Api.Models.Requests.Roles;
using Illegible_Cms_V2.Identity.Api.ResultFilters.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Commands.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Identity.Api.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Create
        [HttpPost(Routes.Roles)]
        [CreateRoleResultFilter]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            // Decode
            var permissionIds = request.PermissionEids.Select(x => x.Decode()).ToList();

            // Operation
            var operation = await _mediator.Send(new CreateRoleCommand(Request.GetRequestInfo())
            {
                Title = request.Title,
                PermissionIds = permissionIds
            });

            return this.ReturnResponse(operation);
        }

        // Get by filter
        [HttpGet(Routes.Roles)]
        [GetRolesByFilterResultFilter]
        public async Task<IActionResult> GetRolesByFilter([FromQuery] GetRolesByFilterRequest request)
        {
            // Decode
            var permissionIds = (request.PermissionEids != null && request.PermissionEids.Any()) ? request.PermissionEids.Select(x => x.Decode()).ToArray() : null;

            // Operation
            var operation = await _mediator.Send(new GetRolesByFilterQuery(Request.GetRequestInfo())
            {
                Filter = new RoleFilter(request.Page, request.PageSize)
                {
                    PermissionIds = permissionIds,
                    SortBy = request.SortBy,
                    Title = request.Title
                },
            });

            return this.ReturnResponse(operation);
        }

        // Get by id
        [HttpGet(Routes.Roles + "{reid}")]
        [GetRoleByIdResultFilter]
        public async Task<IActionResult> GetRoleById([FromRoute] string reid)
        {
            // Decode
            var roleId = reid.Decode();

            // Operation
            var operation = await _mediator.Send(new GetRoleByIdQuery(Request.GetRequestInfo())
            {
                RoleId = roleId
            });

            return this.ReturnResponse(operation);
        }


        // Delete
        [HttpDelete(Routes.Roles + "{reid}")]
        [DeleteRoleResultFilter]
        public async Task<IActionResult> DeleteRole([FromRoute] string reid)
        {
            // Decode
            var roleId = reid.Decode();

            // Operation
            var operation = await _mediator.Send(new DeleteRoleCommand(Request.GetRequestInfo())
            {
                RoleId = roleId
            });

            return this.ReturnResponse(operation);
        }

        // Update
        [HttpPut(Routes.Roles + "{reid}")]
        [UpdateRoleResultFilter]
        public async Task<IActionResult> UpdateRole([FromRoute] string reid, [FromBody] UpdateRoleRequest request)
        {
            // Decode
            var roleId = reid.Decode();
            var permissionIds = request.PermissionEids?.Select(x => x.Decode()).ToList();

            // Operation
            var operation = await _mediator.Send(new UpdateRoleCommand(Request.GetRequestInfo())
            {
                RoleId = roleId,
                Title = request.Title,
                PermissionIds = permissionIds
            });

            return this.ReturnResponse(operation);
        }
    }
}