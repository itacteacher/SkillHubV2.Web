using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsHubV2.Domain.Entities;
[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }

    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
