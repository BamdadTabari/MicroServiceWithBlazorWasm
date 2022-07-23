using Illegible_Cms_V2.Server.Application.Models.Base.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Server.Api.ResultFilters.Weblog.WeblogPostCategoryResults
{
    public class GetWeblogPostCategoryByIdResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is WeblogPostCategoryModel value)
                result.Value = new
                {
                    Eid = value.Id.Encode(),
                    value.CategoryTitle,
                    value.CategoryIcon
                };

            await next();
        }

    }
}
