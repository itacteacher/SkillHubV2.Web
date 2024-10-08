using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsHubV2.Domain.Entities;

[Table("HardSkills")]
public class HardSkill : Skill
{
    public string? Technology { get; set; }
    public int ExperienceYears { get; set; }
}
