using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsHubV2.Domain.Entities;

[Table("SoftSkills")]
public class SoftSkill : Skill
{
    public string? CommunicationStyle { get; set; }
    public int Level { get; set; }
}