using Illegible_Cms_V2.Identity.Application.Models.Filters.Roles;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Identity.Api.Models.Requests.Roles;

public class GetRolesByFilterRequest : PaginationFilter
{
    protected GetRolesByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetRolesByFilterRequest()
    {
    }

    public string? Title { get; set; }
    public List<string>? PermissionEids { get; set; }
    public RoleSortBy? SortBy { get; set; }
}