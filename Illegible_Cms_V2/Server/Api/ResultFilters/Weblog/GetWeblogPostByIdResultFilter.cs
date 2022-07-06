using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Server.Api.ResultFilters.Weblog
{
    public class GetWeblogPostByIdResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is WeblogPostModel value)
                result.Value = new
                {
                    Eid = value.Id.Encode(),
                    Title = value.Title,
                    TextContent = value.TextContent,
                    Summery = value.Summery
                };

            await next();
        }
    }
}
