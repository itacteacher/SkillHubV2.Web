using Microsoft.EntityFrameworkCore;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Data;
public static class DbInitializer
{
    public static void SeedData (ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SoftSkill>().HasData(
            new SoftSkill
            {
                Id = 1,
                Name = "Communication",
                Description = "Ability to communicate with people",
                CommunicationStyle = "Verbal",
                Level = 5
            },
            new SoftSkill
            {
                Id = 2,
                Name = "Teamwork",
                Description = "Ability to work in a group",
                CommunicationStyle = "Group",
                Level = 4
            }
        );

        modelBuilder.Entity<HardSkill>().HasData(
            new HardSkill
            {
                Id = 3,
                Name = "C#",
                Description = "Programming language",
                Technology = "C#",
                Level = 3
            },
            new HardSkill
            {
                Id = 4,
                Name = "SQL",
                Description = "Database management",
                Technology = "SQL Server",
                Level = 2
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "johndoe",
                Email = "johndoe@example.com"
            },
            new User
            {
                Id = 2,
                Username = "janedoe",
                Email = "janedoe@example.com"
            }
        );
    }
}
