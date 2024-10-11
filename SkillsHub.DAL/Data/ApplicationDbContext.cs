using Microsoft.EntityFrameworkCore;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    public DbSet<Skill> Skills { get; set; }
    public DbSet<SoftSkill> SoftSkills { get; set; }
    public DbSet<HardSkill> HardSkills { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SoftSkill>()
            .ToTable("SoftSkills")
            .HasBaseType<Skill>() // Указывает, что SoftSkill наследует от Skill
            .HasOne<Skill>()
            .WithMany()
            .HasForeignKey(ss => ss.Id);

        modelBuilder.Entity<HardSkill>()
            .ToTable("HardSkills")
            .HasBaseType<Skill>() // Указывает, что HardSkill наследует от Skill
            .HasOne<Skill>()
            .WithMany()
            .HasForeignKey(hs => hs.Id);

        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasKey(u => u.Id);

        modelBuilder.Entity<Skill>()
            .ToTable("Skills")
            .HasKey(s => s.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithMany()
            .UsingEntity(j => j.ToTable("UserSkills"));

        DbInitializer.SeedData(modelBuilder);
    }
}