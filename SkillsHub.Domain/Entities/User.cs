using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsHubV2.Domain.Entities;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public ICollection<Skill> Skills { get; set; } = [];
}
