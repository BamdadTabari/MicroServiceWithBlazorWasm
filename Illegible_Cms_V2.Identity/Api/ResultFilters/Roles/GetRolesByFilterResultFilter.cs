using Illegible_Cms_V2.Identity.Application.Models.Base.Roles;
using Illegible_Cms_V2.Shared.BasicShared.Constants.ConstantMethods;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Illegible_Cms_V2.Identity.Api.ResultFilters.Roles
{
    public class GetRolesByFilterResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;

            if (result?.Value is PaginatedList<RoleModel> value)
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
                        CreatorName = x.CreatorName,
                        UpdaterName = x.UpdaterName,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    })
                };

            await next();
        }
    }
}
