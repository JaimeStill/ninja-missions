using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NinjaMissions.Data.Entities;

namespace NinjaMissions.Data.Extensions
{
    public static class NinjaExtensions
    {
        public static async Task<List<Ninja>> GetNinjas(this AppDbContext db)
        {
            var ninjas = await db.Ninjas
                .Include(x => x.Skills)
                    .ThenInclude(x => x.Skill)
                .Include(x => x.Teams)
                    .ThenInclude(x => x.Team)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return ninjas;
        }

        public static async Task<List<Ninja>> SearchNinjas(this AppDbContext db, string search)
        {
            search = search.ToLower();

            var ninjas = await db.Ninjas
                .Include(x => x.Skills)
                    .ThenInclude(x => x.Skill)
                .Include(x => x.Teams)
                    .ThenInclude(x => x.Team)
                .Where(x =>
                    x.Name.ToLower().Contains(search) ||
                    x.Bio.ToLower().Contains(search)
                )
                .OrderBy(x => x.Name)
                .ToListAsync();

            return ninjas;
        }

        public static async Task<Ninja> GetNinja(this AppDbContext db, string name)
        {
            var ninja = await db.Ninjas
                .FirstOrDefaultAsync(x => x.Name.ToLower().Contains(name.ToLower()));

            return ninja;
        }
    }
}