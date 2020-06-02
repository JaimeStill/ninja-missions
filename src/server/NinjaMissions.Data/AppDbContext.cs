using System.Linq;

using Microsoft.EntityFrameworkCore;
using NinjaMissions.Data.Entities;

namespace NinjaMissions.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<NinjaSkill> NinjaSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamNinja> TeamNinjas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ninja>()
                .HasMany(x => x.Skills)
                .WithOne(x => x.Ninja)
                .HasForeignKey(x => x.NinjaId);

            modelBuilder.Entity<Ninja>()
                .HasMany(x => x.Teams)
                .WithOne(x => x.Ninja)
                .HasForeignKey(x => x.NinjaId);

            modelBuilder.Entity<Skill>()
                .HasMany(x => x.Ninjas)
                .WithOne(x => x.Skill)
                .HasForeignKey(x => x.SkillId);

            modelBuilder.Entity<Team>()
                .HasMany(x => x.Ninjas)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);

            modelBuilder
                .Model
                .GetEntityTypes()
                .ToList()
                .ForEach(x =>
                {
                    modelBuilder
                        .Entity(x.Name)
                        .ToTable(x.Name.Split('.').Last());
                });
        }
    }
}