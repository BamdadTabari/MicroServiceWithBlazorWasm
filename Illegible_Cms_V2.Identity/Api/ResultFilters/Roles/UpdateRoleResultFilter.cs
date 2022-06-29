using Illegible_Cms_V2.Identity.Domain.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Roles
{
    public class UpdateRoleResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is Role value)
                result.Value = new
                {
                    Eid = value.Id.Encode(),
                    UpdatedAt = value.UpdatedAt
                };

            await next();
        }
    }
}
