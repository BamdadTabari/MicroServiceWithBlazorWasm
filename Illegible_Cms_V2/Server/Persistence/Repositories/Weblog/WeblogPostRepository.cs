using Illegible_Cms_V2.Server.Application.Interfaces.Repositories.Weblog;
using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostFilters;
using Illegible_Cms_V2.Server.Domain.Weblog;
using Illegible_Cms_V2.Server.Persistence.Extensions.Weblog;
using Illegible_Cms_V2.Shared.BasicShared.Extension;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Server.Persistence.Repositories.Weblog
{
    public class WeblogPostRepository : Repository<WeblogPost>, IWeblogPostRepository
    {
        private readonly IQueryable<WeblogPost> _queryable;

        public WeblogPostRepository(AppDbContext dbContext) : base(dbContext)
        {
            _queryable = DbContext.Set<WeblogPost>();
        }

        public async Task<int> CountWeblogPostsByFilterAsync(WeblogPostFilter filter)
        {
            var query = _queryable;

            query = query.ApplyFilter(filter);

            return await query.CountAsync();
        }

        public async Task<WeblogPost> GetWeblogPostByIdAsync(int id)
        {
            var data = await _queryable.SingleOrDefaultAsync(x => x.Id == id);

            if (data == null)
                throw new NullReferenceException("Weblog post not found with this id");

            return data;
        }

        public async Task<WeblogPost> GetWeblogPostByWeblogPostNameAsync(string weblogPostname)
        {
            var data = await _queryable.SingleOrDefaultAsync(x => x.Title == weblogPostname);

            if (data == null)
                throw new NullReferenceException("Weblog post not found with this name");

            return data;
        }

        public async Task<List<WeblogPost>> GetWeblogPostsByFilterAsync(WeblogPostFilter filter)
        {
            var query = _queryable;

            query = query.AsNoTracking();
            query = query.ApplyFilter(filter);
            query = query.ApplySort(filter.SortBy);

            return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
        }

        public async Task<List<WeblogPost>> GetWeblogPostsByIdsAsync(IEnumerable<int> ids)
        {
            var query = _queryable;

            if (ids?.Any() == true)
                query = query.Where(x => ids.Contains(x.Id));

            //todo: query = query.ApplySort('by time');

            return await query.ToListAsync();
        }
    }
}
