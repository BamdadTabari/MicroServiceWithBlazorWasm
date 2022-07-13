using Illegible_Cms_V2.Identity.Application.Models.Base.Users;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Users
{
    public class GetUserByFilterResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is PaginatedList<UserModel> value)
                result.Value = new
                {
                    value.Page,
                    value.PageSize,
                    value.TotalCount,
                    Data = value.Data.Select(x => new
                    {
                        Eid = x.Id.Encode(),
                        Username = x.Username,
                        IsEmailConfirmed = x.IsEmailConfirmed,
                        IsMobileConfirmed = x.IsMobileConfirmed,
                        IsLockedOut = x.IsLockedOut,
                        Mobile = x.Mobile,


                        RoleTitles = x.UserRoles.Select(x => x.Role.Title),

                        Email = x.Email,
                        State = nameof(x.State),
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    })
                };

            await next();
        }
    }
}
