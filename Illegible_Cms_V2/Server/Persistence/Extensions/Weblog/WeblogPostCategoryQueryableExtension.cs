using Illegible_Cms_V2.Server.Application.Models.Filters.Weblog.WeblogPostCategoryFilters;
using Illegible_Cms_V2.Server.Domain.Weblog;

namespace Illegible_Cms_V2.Server.Persistence.Extensions.Weblog
{
    public static class WeblogPostCategoryQueryableExtension
    {
        public static IQueryable<WeblogPostCategory> ApplyFilter(this IQueryable<WeblogPostCategory> query, WeblogPostCategoryFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.KeyWord))
                query = query.Where(x =>
                    x.CategoryTitle.ToLower().Contains(filter.KeyWord.ToLower().Trim()));
            return query;
        }

        public static IQueryable<WeblogPostCategory> ApplySort(this IQueryable<WeblogPostCategory> query, WeblogPostCategorySortBy sortBy)
        {
            return sortBy switch
            {
                WeblogPostCategorySortBy.CreationDate => query.OrderBy(x => x.CreatedAt),
                WeblogPostCategorySortBy.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.Id)
            };
        }
    }
}
