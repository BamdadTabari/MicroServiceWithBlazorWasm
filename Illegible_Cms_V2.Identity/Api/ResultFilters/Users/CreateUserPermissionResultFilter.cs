using Illegible_Cms_V2.Identity.Domain.Claims;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Users
{
    public class CreateUserPermissionResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is Claim value)
                result.Value = new
                {
                    Eid = value.Id.Encode(),
                    Value = value.Value
                };

            await next();
        }
    }
}
