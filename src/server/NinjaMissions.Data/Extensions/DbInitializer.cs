using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NinjaMissions.Data.Entities;

namespace NinjaMissions.Data.Extensions
{
    public static class DbInitializer
    {
        public static async Task Initialize(this AppDbContext db)
        {
            Console.WriteLine("Initializing database");
            await db.Database.MigrateAsync();
            Console.WriteLine("Database initialized");
            Console.WriteLine();

            List<Ninja> ninjas;
            List<Skill> skills;
            List<Team> teams;

            if (!(await db.Ninjas.AnyAsync()))
            {
                Console.WriteLine("Seeding Ninjas...");
                ninjas = await db.SeedNinjas();
            }
            else
            {
                Console.WriteLine("Retrieving Ninjas...");
                ninjas = await db.Ninjas.ToListAsync();
            }

            if (!(await db.Skills.AnyAsync()))
            {
                Console.WriteLine("Seeding Skills...");
                skills = await db.SeedSkills();
            }
            else
            {
                Console.WriteLine("Retrieving Skills...");
                skills = await db.Skills.ToListAsync();
            }

            if (!(await db.Teams.AnyAsync()))
            {
                Console.WriteLine("Seeding Teams...");
                teams = await db.SeedTeams();
            }
            else
            {
                Console.WriteLine("Retrieving Teams...");
                teams = await db.Teams.ToListAsync();
            }

            var kakashi = ninjas.FirstOrDefault(x => x.Name.StartsWith("Kakashi"));
            var naruto = ninjas.FirstOrDefault(x => x.Name.StartsWith("Naruto"));
            var sasuke = ninjas.FirstOrDefault(x => x.Name.StartsWith("Sasuke"));
            var sakura = ninjas.FirstOrDefault(x => x.Name.StartsWith("Sakura"));

            var guy = ninjas.FirstOrDefault(x => x.Name.StartsWith("Might"));
            var lee = ninjas.FirstOrDefault(x => x.Name.StartsWith("Rock"));
            var tenten = ninjas.FirstOrDefault(x => x.Name.StartsWith("Tenten"));
            var neji = ninjas.FirstOrDefault(x => x.Name.StartsWith("Neji"));

            var asuma = ninjas.FirstOrDefault(x => x.Name.StartsWith("Asuma"));
            var shikamaru = ninjas.FirstOrDefault(x => x.Name.StartsWith("Shikamaru"));
            var choji = ninjas.FirstOrDefault(x => x.Name.StartsWith("Choji"));
            var ino = ninjas.FirstOrDefault(x => x.Name.StartsWith("Ino"));

            if (!(await db.TeamNinjas.AnyAsync()))
            {
                Console.WriteLine("Seeding Team Ninjas...");

                var team7 = teams.FirstOrDefault(x => x.Name == "Team 7");
                var team10 = teams.FirstOrDefault(x => x.Name == "Team 10");
                var teamGuy = teams.FirstOrDefault(x => x.Name == "Team Guy");

                var teamNinjas = new List<TeamNinja>
                {
                    new TeamNinja
                    {
                        TeamId = team7.Id,
                        NinjaId = kakashi.Id,
                        IsLeader = true
                    },
                    new TeamNinja
                    {
                        TeamId = team7.Id,
                        NinjaId = naruto.Id
                    },
                    new TeamNinja
                    {
                        TeamId = team7.Id,
                        NinjaId = sasuke.Id
                    },
                    new TeamNinja
                    {
                        TeamId = team7.Id,
                        NinjaId = sakura.Id
                    },
                    new TeamNinja
                    {
                        TeamId = team10.Id,
                        NinjaId = asuma.Id,
                        IsLeader = true
                    },
                    new TeamNinja
                    {
                        TeamId = team10.Id,
                        NinjaId = shikamaru.Id
                    },
                    new TeamNinja
                    {
                        TeamId = team10.Id,
                        NinjaId = choji.Id
                    },
                    new TeamNinja
                    {
                        TeamId = team10.Id,
                        NinjaId = ino.Id
                    },
                    new TeamNinja
                    {
                        TeamId = teamGuy.Id,
                        NinjaId = guy.Id,
                        IsLeader = true
                    },
                    new TeamNinja
                    {
                        TeamId = teamGuy.Id,
                        NinjaId = lee.Id
                    },
                    new TeamNinja
                    {
                        TeamId = teamGuy.Id,
                        NinjaId = tenten.Id
                    },
                    new TeamNinja
                    {
                        TeamId = teamGuy.Id,
                        NinjaId = neji.Id
                    }
                };

                await db.TeamNinjas.AddRangeAsync(teamNinjas);
                await db.SaveChangesAsync();
            }

            if (!(await db.NinjaSkills.AnyAsync()))
            {
                Console.WriteLine("Seeding Ninja Skills...");

                var taijutsu = skills.FirstOrDefault(x => x.Name == "Taijutsu");
                var ninjutsu = skills.FirstOrDefault(x => x.Name == "Ninjutsu");
                var genjutsu = skills.FirstOrDefault(x => x.Name == "Genjutsu");

                var ninjaSkills = new List<NinjaSkill>
                {
                    new NinjaSkill
                    {
                        NinjaId = guy.Id,
                        SkillId = taijutsu.Id,
                        Strength = 10
                    },
                    new NinjaSkill
                    {
                        NinjaId = lee.Id,
                        SkillId = taijutsu.Id,
                        Strength = 10
                    },
                    new NinjaSkill
                    {
                        NinjaId = tenten.Id,
                        SkillId = taijutsu.Id,
                        Strength = 8
                    },
                    new NinjaSkill
                    {
                        NinjaId = neji.Id,
                        SkillId = taijutsu.Id,
                        Strength = 6
                    },
                    new NinjaSkill
                    {
                        NinjaId = sasuke.Id,
                        SkillId = taijutsu.Id,
                        Strength = 7
                    },
                    new NinjaSkill
                    {
                        NinjaId = neji.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 8
                    },
                    new NinjaSkill
                    {
                        NinjaId = tenten.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 4
                    },
                    new NinjaSkill
                    {
                        NinjaId = kakashi.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 10
                    },
                    new NinjaSkill
                    {
                        NinjaId = naruto.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 10
                    },
                    new NinjaSkill
                    {
                        NinjaId = sasuke.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 7
                    },
                    new NinjaSkill
                    {
                        NinjaId = sakura.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 8
                    },
                    new NinjaSkill
                    {
                        NinjaId = asuma.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 6
                    },
                    new NinjaSkill
                    {
                        NinjaId = shikamaru.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 9
                    },
                    new NinjaSkill
                    {
                        NinjaId = choji.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 6
                    },
                    new NinjaSkill
                    {
                        NinjaId = ino.Id,
                        SkillId = ninjutsu.Id,
                        Strength = 7
                    },
                    new NinjaSkill
                    {
                        NinjaId = kakashi.Id,
                        SkillId = genjutsu.Id,
                        Strength = 6
                    },
                    new NinjaSkill
                    {
                        NinjaId = sasuke.Id,
                        SkillId = genjutsu.Id,
                        Strength = 7
                    }
                };

                await db.NinjaSkills.AddRangeAsync(ninjaSkills);
                await db.SaveChangesAsync();
            }
        }

        static async Task<List<Ninja>> SeedNinjas(this AppDbContext db)
        {
            var ninjas = new List<Ninja>
            {
                new Ninja
                {
                    Name = "Kakashi Hatake",
                    Age = 30,
                    Bio = "Copy Ninja Kakashi, Kakashi of the Sharingan",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Naruto Uzumaki",
                    Age = 14,
                    Bio = "The Show-Off, Number One Unpredictable, Noisy Ninja",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Sasuke Uchiha",
                    Age = 15,
                    Bio = "Sasuke of the Sharingan",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Sakura Haruno",
                    Age = 14,
                    Bio = "A Kunoichi of Konohagakure",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Might Guy",
                    Age = 30,
                    Bio = "Konoha's Sublime Green Beast of Prey, Bushy Brows Sensei",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Rock Lee",
                    Age = 15,
                    Bio = "Bushy Brows, Konoha's Beautiful Green Wild Beast",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Neji Hyuga",
                    Age = 16,
                    Bio = "Though a prodigy even by the Hyūga's standards, Neji was a member of the clan's branch house; no matter how skilled he became, he would always be in service to the Hyūga's main house, a fact that convinced him fate was predetermined.",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Tenten",
                    Age = 15,
                    Bio = "A Kunoichi from Konohagakure",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Asuma Sarutobi",
                    Age = 28,
                    Bio = "Was a jōnin of Konohagakure's Sarutobi clan and a former member of the Twelve Guardian Ninja.",
                    IsActive = false
                },
                new Ninja
                {
                    Name = "Shikamaru Nara",
                    Age = 13,
                    Bio = "Though lazy by nature, Shikamaru has a rare intellect that consistently allows him to prevail in combat.",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Choji Akimichi",
                    Age = 13,
                    Bio = "Though sensitive about his weight, Chōji is nevertheless dedicated to his friends, especially in Team Asuma.",
                    IsActive = true
                },
                new Ninja
                {
                    Name = "Ino Yamanaka",
                    Age = 14,
                    Bio = "Ino is the only child of Inoichi Yamanaka and was a popular student during her time in the Academy.",
                    IsActive = true
                }
            };

            await db.Ninjas.AddRangeAsync(ninjas);
            await db.SaveChangesAsync();

            return ninjas;
        }

        static async Task<List<Skill>> SeedSkills(this AppDbContext db)
        {
            var skills = new List<Skill>
            {
                new Skill
                {
                    Name = "Taijutsu",
                    Description = "A basic form of techniques and refers to any techniques involving the martial arts or the optimisation of natural human abilities."
                },
                new Skill
                {
                    Name = "Ninjutsu",
                    Description = "Simply described as anything that is not genjutsu or taijutsu. Most ninjutsu require chakra and hand seals, but that is not always the case since mere usage of weaponry qualifies as ninjutsu."
                },
                new Skill
                {
                    Name = "Genjutsu",
                    Description = "Unlike ninjutsu, the effects of genjutsu are not real, being only sensory illusions experienced by those who fall victim to it."
                }
            };

            await db.Skills.AddRangeAsync(skills);
            await db.SaveChangesAsync();

            return skills;
        }

        static async Task<List<Team>> SeedTeams(this AppDbContext db)
        {
            var teams = new List<Team>
            {
                new Team
                {
                    Name = "Team 7"
                },
                new Team
                {
                    Name = "Team 10"
                },
                new Team
                {
                    Name = "Team Guy"
                }
            };

            await db.Teams.AddRangeAsync(teams);
            await db.SaveChangesAsync();

            return teams;
        }
    }
}