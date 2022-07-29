using Illegible_Cms_V2.Server.Application.Interfaces.Repositories.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostCategoryFilters;
using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Server.Persistence.Extensions.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Server.Persistence.Repositories.Weblog;

public class WeblogPostCategoryRepository : Repository<WeblogPostCategory>, IWeblogPostCategoryRepository
{
    private readonly IQueryable<WeblogPostCategory> _queryable;

    public WeblogPostCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
        _queryable = DbContext.Set<WeblogPostCategory>();
    }

    public async Task<int> CountWeblogPostCategoriesByFilterAsync(WeblogPostCategoryFilter filter)
    {
        var query = _queryable;

        query = query.ApplyFilter(filter);

        return await query.CountAsync();
    }

    public async Task<WeblogPostCategory> GetWeblogPostCategoryByIdAsync(int id)
    {
        var data = await _queryable.SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException("Weblog post category not found with this id");

        return data;
    }

    public async Task<WeblogPostCategory> GetWeblogPostCategoryByWeblogPostCategoryTitleAsync(string weblogPostCategoryTitle)
    {
        var data = await _queryable.SingleOrDefaultAsync(x => x.CategoryTitle == weblogPostCategoryTitle);

        if (data == null)
            throw new NullReferenceException("Weblog post category not found with this name");

        return data;
    }

    public async Task<List<WeblogPostCategory>> GetWeblogPostCategoriesByFilterAsync(WeblogPostCategoryFilter filter)
    {
        var query = _queryable;

        query = query.AsNoTracking();
        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<List<WeblogPostCategory>> GetWeblogPostCategoriesByIdsAsync(IEnumerable<int> ids)
    {
        var query = _queryable;

        if (ids?.Any() == true)
            query = query.Where(x => ids.Contains(x.Id));

        //todo: query = query.ApplySort('by time');

        return await query.ToListAsync();
    }
}