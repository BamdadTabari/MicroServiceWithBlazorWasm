using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Client.ClientObjects.Requests.Identity.Permissions;

public class GetPermissionsByFilterRequest : PaginationFilter
{
    protected GetPermissionsByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }
    public GetPermissionsByFilterRequest()
    {
    }

    public string? RoleEid { get; set; }
    public string? Value { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
}