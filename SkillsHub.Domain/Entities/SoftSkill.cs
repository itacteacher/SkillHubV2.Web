using SkillsHubV2.Domain.Validators;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsHubV2.Domain.Entities;

[Table("SoftSkills")]
public class SoftSkill : Skill
{
    [NoPalindromeAttribute]
    public string? CommunicationStyle { get; set; }
    public int Level { get; set; }
}