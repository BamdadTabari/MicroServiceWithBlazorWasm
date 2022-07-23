using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostFilters;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Persistence.Extensions.Weblog
{
    public static class WeblogPostQueryableExtension
    {
        public static IQueryable<WeblogPost> ApplyFilter(this IQueryable<WeblogPost> query, WeblogPostFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.KeyWord))
                query = query.Where(x =>
                    x.Title.ToLower().Contains(filter.KeyWord.ToLower().Trim()));

            return query;
        }

        public static IQueryable<WeblogPost> ApplySort(this IQueryable<WeblogPost> query, WeblogPostSortBy? sortBy)
        {
            return sortBy switch
            {
                WeblogPostSortBy.CreationDate => query.OrderBy(x => x.CreatedAt),
                WeblogPostSortBy.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.Id)
            };
        }
    }
}
