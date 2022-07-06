using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Server.Api.ResultFilters.Weblog
{
    public class GetWeblogPostByFilterResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is PaginatedList<WeblogPostModel> value)
                result.Value = new
                {
                    value.Page,
                    value.PageSize,
                    value.TotalCount,
                    Data = value.Data.Select(x => new
                    {
                        Eid = x.Id.Encode(),
                        Title = x.Title,
                        Summery = x.Summery,
                        TextContent = x.TextContent
                      
                    })
                };

            await next();
        }
    }
}