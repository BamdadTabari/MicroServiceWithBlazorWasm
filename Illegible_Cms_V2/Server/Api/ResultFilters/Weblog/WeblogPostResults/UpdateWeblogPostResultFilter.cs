using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Server.Api.ResultFilters.Weblog.WeblogPostResults;

public class UpdateWeblogPostResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is WeblogPost value)
            result.Value = new
            {
                Eid = value.Id.Encode(),
                value.Title,
            };

        await next();
    }
}