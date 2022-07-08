using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Roles
{
    public class GetRoleByIdResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is RoleModel value)
                result.Value = new
                {
                    Eid = value.Id.Encode(),
                    Title = value.Title,
                    CreatorId = value.CreatorId,
                    UpdaterId = value.UpdaterId,
                    CreatedAt = value.CreatedAt,
                    UpdatedAt = value.UpdatedAt,
                    Permissions = value.Permissions.Select(x => new
                    {
                        Eid = x.Id.Encode(),
                        Title = x.Title,
                        Name = x.Name,
                        Value = x.Value
                    })
                };

            await next();
        }
    }
}
