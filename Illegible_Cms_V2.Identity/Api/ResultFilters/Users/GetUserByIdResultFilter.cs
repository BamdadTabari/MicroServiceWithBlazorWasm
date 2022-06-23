using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Users
{
    public class GetUserByIdResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is UserModel value)
                result.Value = new
                {
                    Eid = value.Id.Encode(),
                    Username = value.Username,
                    IsEmailConfirmed = value.IsEmailConfirmed,
                    IsMobileConfirmed = value.IsMobileConfirmed,
                    IsLockedOut = value.IsLockedOut,
                    Mobile = value.Mobile,
                    
                    RoleTitles = value.UserRoles.Select(x => x.Name),

                    Email = value.Email,
                    State = nameof(value.State),
                    CreatedAt = value.CreatedAt,
                    UpdatedAt = value.UpdatedAt
                };

            await next();
        }
    }
}