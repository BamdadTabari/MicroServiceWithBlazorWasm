﻿using Illegible_Cms_V2.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Persistence.Seeding.Seeds;

internal static class RoleSeed
{
    public static List<Role> All => new List<Role>
    {
        new Role()
        {
            Id = 1,
            Title = "Owner",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        }
    };

    public static void Run(IServiceScope scope)
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var roleSeeds = RoleSeed.All;
        var roleSeedNames = roleSeeds.ConvertAll(x => x.Title.ToLower());

        var toBeUpdatedRoles = context.Roles
            .Include(x => x.RolePermission)
            .Where(x => roleSeedNames.Contains(x.Title.ToLower()))
            .ToList();

        var toBeAddedRoles = roleSeeds
            .Where(x => !toBeUpdatedRoles.ConvertAll(y => y.Title.ToLower()).Contains(x.Title));

        foreach (var item in toBeUpdatedRoles)
        {
            var seed = roleSeeds.Single(x => x.Title.ToLower() == item.Title.ToLower());
            item.RolePermission = seed.RolePermission;
            item.UpdatedAt = DateTime.UtcNow;
        }

        foreach (var item in toBeAddedRoles)
        {
            context.Roles.Add(item);
        }
    }
}