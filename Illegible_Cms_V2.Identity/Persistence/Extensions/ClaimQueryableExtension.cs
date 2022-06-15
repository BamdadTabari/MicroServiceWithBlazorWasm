using Illegible_Cms_V2.Identity.Application.Models.Filters.Claims;
using Illegible_Cms_V2.Identity.Domain.Claims;

namespace Illegible_Cms_V2.Identity.Persistence.Extensions
{
    public static class ClaimQueryableExtension
    {
        public static IQueryable<Claim> ApplyFilter(this IQueryable<Claim> query, ClaimFilter filter)
        {
            // Filter By RoleId
            if (filter.UserId.HasValue)
                query = query.Where(x => x.UserId == filter.UserId.Value);

            /// Filter By Value
            if (!string.IsNullOrEmpty(filter.Value))
                query = query.Where(x => x.Value.ToLower().Contains(filter.Value.ToLower().Trim()));

            return query;
        }

        public static IQueryable<Claim> ApplySort(this IQueryable<Claim> query, ClaimSortBy? sortBy)
        {
            return sortBy switch
            {
                ClaimSortBy.CreationDate => query.OrderBy(x => x.CreatedAt),
                ClaimSortBy.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.Id)
            };
        }
    }
}

