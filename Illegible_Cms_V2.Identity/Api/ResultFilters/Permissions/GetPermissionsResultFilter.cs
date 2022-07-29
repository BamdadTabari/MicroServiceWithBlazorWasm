using Illegible_Cms_V2.Identity.Application.Models.Base.Permissions;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Permissions;

public class GetPermissionsResultFilter : ResultFilterAttribute
{
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var result = context.Result as ObjectResult;

        if (result?.Value is PaginatedList<PermissionModel> value)
            result.Value = new
            {
                value.Page,
                value.PageSize,
                value.TotalCount,
                Data = value.Data.Select(x => new
                {
                    Eid = x.Id.Encode(),
                    Title = x.Title,
                    Name = x.Name,
                    Value = x.Value,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
            };

        await next();
    }
}