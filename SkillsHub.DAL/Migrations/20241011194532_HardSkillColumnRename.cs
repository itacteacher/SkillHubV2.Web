using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillsHubV2.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HardSkillColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExperienceYears",
                table: "HardSkills",
                newName: "Level");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "HardSkills",
                newName: "ExperienceYears");
        }
    }
}
