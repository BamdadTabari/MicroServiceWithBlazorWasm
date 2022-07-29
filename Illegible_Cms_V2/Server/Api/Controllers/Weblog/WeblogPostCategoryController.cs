using Illegible_Cms_V2.Server.Api.Models.Requests.Weblog.WeblogPostCategoryRequests;
using Illegible_Cms_V2.Server.Api.ResultFilters.Weblog.WeblogPostCategoryResults;
using Illegible_Cms_V2.Server.Application.Models.Commands.Weblog.WeblogPostCategoryCommands;
using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostCategoryFilters;
using Illegible_Cms_V2.Server.Application.Models.Queries.Weblog.WeblogPostCategoryQueries;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Illegible_Cms_V2.Server.Api.Controllers.Weblog;

public class WeblogPostCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeblogPostCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Routes.WeblogPostCategory + "AddPostCategory")]
    [CreateWeblogPostCategoryResultFilter]
    public async Task<IActionResult> AddWeblogPostCategory([FromBody] CreateWeblogPostCategoryRequest request)
    {
        var operation = await _mediator.Send(new CreateWeblogPostCategoryCommand(Request.GetRequestInfo())
        {
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryIcon
        });

        return this.ReturnResponse(operation);
    }

    [HttpPut(Routes.WeblogPostCategory + "update/{wpceid}")]
    [UpdateWeblogPostCategoryResultFilter]
    public async Task<IActionResult> UpdateWeblogPostCategory([FromRoute] string wpceid, [FromBody] UpdateWeblogPostCategoryRequest request)
    {
        var Id = wpceid.Decode();

        var operation = await _mediator.Send(new UpdateWeblogPostCategoryCommand(Request.GetRequestInfo())
        {
            Id = Id,
            CategoryTitle = request.CategoryTitle,
            CategoryIcon = request.CategoryIcon
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.WeblogPostCategory + "get_by_id/{wpceid}")]
    [GetWeblogPostCategoryByIdResultFilter]
    public async Task<IActionResult> GetWeblogPostCategoryById([FromRoute] string wpceid)
    {
        var Id = wpceid.Decode();

        var operation = await _mediator.Send(new GetWeblogPostCategoryByIdQuery(Request.GetRequestInfo())
        {
            Id = Id,
        });

        return this.ReturnResponse(operation);
    }

    [HttpGet(Routes.WeblogPostCategory + "get_weblogpostCategories_by_filter")]
    [GetWeblogPostCategoryByFilterResultFilter]
    public async Task<IActionResult> GetWeblogPostCategoriesByFilter([FromQuery] GetWeblogPostCategoryByFilterRequst request)
    {
        var operation = await _mediator.Send(new GetWeblogPostCategoryByFilterQuery(Request.GetRequestInfo())
        {
            Filter = new WeblogPostCategoryFilter(request.Page, request.PageSize)
            {
                KeyWord = request?.Keyword ?? "",
                SortBy = request.SortBy,
            },
        });

        return this.ReturnResponse(operation);
    }

    [HttpDelete(Routes.WeblogPostCategory + "{wpceid}")]
    [DeleteWeblogPostCategoryResultFilter]
    public async Task<IActionResult> DeleteWeblogPostCategory([FromRoute] string wpceid)
    {
        var Id = wpceid.Decode();

        var operation = await _mediator.Send(new DeleteWeblogPostCategoryCommand(Request.GetRequestInfo())
        {
            Id = Id,
        });

        return this.ReturnResponse(operation);
    }
}