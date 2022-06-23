using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Auth
{
    public class GetProfileResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is UserModel value)
                result.Value = new
                {
                    value.Id,
                    value.Username,
                    Roles = value.UserRoles.Select(x => new
                    {
                        Id = x.RoleId.Encode(),
                        Name = x.Name
                    }),
                    value.Email,
                    value.CreatedAt,
                    value.UpdatedAt
                };

            await next();
        }
    }
}
