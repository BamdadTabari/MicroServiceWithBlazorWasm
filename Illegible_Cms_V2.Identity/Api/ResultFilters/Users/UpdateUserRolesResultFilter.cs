using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Users;

public class UpdateUserRolesResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is UserRole value)
            result.Value = new
            {
                RoleId = value.RoleId.Encode(),
                UserId = value.UserId.Encode()
            };

        await next();
    }
}