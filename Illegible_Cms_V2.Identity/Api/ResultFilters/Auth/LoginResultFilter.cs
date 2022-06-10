using Illegible_Cms_V2.Identity.Application.Models.Results.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Auth
{
    public class LoginResultFilter: ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is LoginResult value)
                result.Value = new
                {
                    Username = value.UserName,
                    FullName = value.FullName,
                    AccessToken = value.AccessToken,
                    RefreshToken = value.RefreshToken,
                };

            await next();
        }
    }
}
