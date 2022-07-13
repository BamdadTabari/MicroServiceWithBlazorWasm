using Illegible_Cms_V2.Server.Api.Models.Requests.Weblog;
using Illegible_Cms_V2.Server.Api.ResultFilters.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Queries.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Server.Api.Controllers.Weblog
{
    public class WeblogPostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeblogPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.Weblog + "AddPost")]
        [CreateWeblogPostResultFilter]
        public async Task<IActionResult> AddWeblogPost([FromBody] CreateWeblogPostRequest request)
        {
            var operation = await _mediator.Send(new CreateWeblogPostCommand(Request.GetRequestInfo())
            {
                Title = request.Title,
                TextContent = request.TextContent,
                Summery = request.Summery,
            });

            return this.ReturnResponse(operation);
        }

        [HttpPut(Routes.Weblog + "update/{wpeid}")]
        [UpdateWeblogPostResultFilter]
        public async Task<IActionResult> UpdateWeblogPost([FromRoute] string wpeid, [FromBody] UpdateWeblogPostRequest request)
        {
            var Id = wpeid.Decode();

            var operation = await _mediator.Send(new UpdateWeblogPostCommand(Request.GetRequestInfo())
            {
                Id = Id,
                Summery = request.Summery,
                Title = request.Title,
                TextContent = request.TextContent,
            });

            return this.ReturnResponse(operation);
        }

        [HttpGet(Routes.Weblog + "get_by_id/{wpeid}")]
        [GetWeblogPostByIdResultFilter]
        public async Task<IActionResult> GetWeblogPostById([FromRoute] string wpeid)
        {
            var Id = wpeid.Decode();

            var operation = await _mediator.Send(new GetWeblogPostByIdQuery(Request.GetRequestInfo())
            {
                WeblogPostId = Id,
            });

            return this.ReturnResponse(operation);
        }

        [HttpGet(Routes.Weblog + "get_weblogs_by_filter")]
        [GetWeblogPostByFilterResultFilter]
        public async Task<IActionResult> GetWeblogPostsByFilter([FromQuery] GetWeblogPostByFilterRequest request)
        {
            var operation = await _mediator.Send(new GetWeblogPostByFilterQuery(Request.GetRequestInfo())
            {
                Filter = new WeblogPostFilter(request.Page, request.PageSize)
                {
                    KeyWord = request?.Keyword ?? "",
                    SortBy = request?.SortBy,
                },
            });

            return this.ReturnResponse(operation);
        }

        [HttpDelete(Routes.Weblog + "{wpeid}")]
        [DeleteWeblogPostResultFilter]
        public async Task<IActionResult> DeleteWeblogPost([FromRoute] string wpeid)
        {
            var Id = wpeid.Decode();

            var operation = await _mediator.Send(new DeleteWeblogPostCommand(Request.GetRequestInfo())
            {
                Id = Id,
            });

            return this.ReturnResponse(operation);
        }
    }
}
