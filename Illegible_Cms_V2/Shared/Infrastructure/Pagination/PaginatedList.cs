namespace Illegible_Cms_V2.Shared.Infrastructure.Pagination;

public class PaginatedList<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public IList<T> Data { get; set; }
}