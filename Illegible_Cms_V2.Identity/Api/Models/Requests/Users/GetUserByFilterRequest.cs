using Illegible_Cms_V2.Identity.Application.Models.Filters.Users;
using Illegible_Cms_V2.Identity.Domain.Users;
using Illegible_Cms_V2.Shared.Infrastructure.Pagination;

namespace Illegible_Cms_V2.Identity.Api.Models.Requests.Users;

public class GetUserByFilterRequest : PaginationFilter
{
    protected GetUserByFilterRequest(int page, int pageSize) : base(page, pageSize)
    {
    }

    public GetUserByFilterRequest()
    {
    }

    public string? Keyword { get; set; }
    public string? Email { get; set; }
    public List<UserState>? States { get; set; }
    public UserSortBy? SortBy { get; set; }
}