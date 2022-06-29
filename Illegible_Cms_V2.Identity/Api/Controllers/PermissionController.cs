using Illegible_Cms_V2.Identity.Api.Models.Requests.Permissions;
using Illegible_Cms_V2.Identity.Api.ResultFilters.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Filters.Permissions;
using Illegible_Cms_V2.Identity.Application.Models.Queries.Permissions;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Identity.Api.Controllers
{
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get by filter
        [HttpGet(Routes.Permissions)]
        [GetPermissionsResultFilter]
        public async Task<IActionResult> GetPermissionsByFilter([FromQuery] GetPermissionsByFilterRequest request)
        {
            // Decode
            var roleId = request.RoleEid?.Decode();

            // Operation
            var operation = await _mediator.Send(new GetPermissionsByFilterQuery(Request.GetRequestInfo())
            {
                Filter = new PermissionFilter(request.Page, request.PageSize)
                {
                    RoleId = roleId,
                    Value = request.Value,
                    Name = request.Name,
                    Title = request.Title
                },
            });

            return this.ReturnResponse(operation);
        }
    }
}
