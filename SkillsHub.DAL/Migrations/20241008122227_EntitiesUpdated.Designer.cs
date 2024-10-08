﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillsHubV2.DAL.Data;

#nullable disable

namespace SkillsHubV2.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241008122227_EntitiesUpdated")]
    partial class EntitiesUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johndoe@example.com",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "janedoe@example.com",
                            Username = "janedoe"
                        });
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.UserSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SkillId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            SkillId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            SkillId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            SkillId = 4,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.HardSkill", b =>
                {
                    b.HasBaseType("SkillsHubV2.Domain.Entities.Skill");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("Technology")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("HardSkills", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Description = "Programming language",
                            Name = "C#",
                            ExperienceYears = 3,
                            Technology = "C#"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Database management",
                            Name = "SQL",
                            ExperienceYears = 2,
                            Technology = "SQL Server"
                        });
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.SoftSkill", b =>
                {
                    b.HasBaseType("SkillsHubV2.Domain.Entities.Skill");

                    b.Property<string>("CommunicationStyle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.ToTable("SoftSkills", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ability to communicate with people",
                            Name = "Communication",
                            CommunicationStyle = "Verbal",
                            Level = 5
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ability to work in a group",
                            Name = "Teamwork",
                            CommunicationStyle = "Group",
                            Level = 4
                        });
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.UserSkill", b =>
                {
                    b.HasOne("SkillsHubV2.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillsHubV2.Domain.Entities.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.HardSkill", b =>
                {
                    b.HasOne("SkillsHubV2.Domain.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.SoftSkill", b =>
                {
                    b.HasOne("SkillsHubV2.Domain.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillsHubV2.Domain.Entities.User", b =>
                {
                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
