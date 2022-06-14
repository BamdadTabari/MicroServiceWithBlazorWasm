﻿using Illegible_Cms_V2.Identity.Application.Models.Filters.Users;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Persistence.Extensions
{
    public static class UserQueryableExtension
    {
        public static IQueryable<User> ApplyFilter(this IQueryable<User> query, UserFilter filter)
        {
            // Filter by keyword
            if (!string.IsNullOrEmpty(filter.Keyword))
                query = query.Where(x =>
                    x.Username.ToLower().Contains(filter.Keyword.ToLower().Trim()));

            // Filter by email
            if (!string.IsNullOrEmpty(filter.Email))
                query = query.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower().Trim()));

            // Filter by statuses
            if (filter.States?.Any() == true)
                query = query.Where(x => filter.States.Contains(x.State));

            return query;
        }

        public static IQueryable<User> ApplySort(this IQueryable<User> query, UserSortBy? sortBy)
        {
            return sortBy switch
            {
                UserSortBy.CreationDate => query.OrderBy(x => x.CreatedAt),
                UserSortBy.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
                UserSortBy.LastLoginDate => query.OrderBy(x => x.LastLoginDate),
                UserSortBy.LastLoginDateDescending => query.OrderByDescending(x => x.LastLoginDate),
                _ => query.OrderByDescending(x => x.Id)
            };
        }
    }
}