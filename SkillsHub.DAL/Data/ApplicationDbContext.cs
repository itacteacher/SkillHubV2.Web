using Microsoft.EntityFrameworkCore;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    public DbSet<Skill> Skill { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add seed data for Skills table.
        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "C#", Description = "Programming language for .NET platform" },
            new Skill { Id = 2, Name = "ASP.NET Core", Description = "Framework for building web applications" },
            new Skill { Id = 3, Name = "Entity Framework", Description = "Object-relational mapper for .NET" }
        );
    }
}
