using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillsHubV2.Domain.Entities;

[Table("UserSkills")]
public class UserSkill
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; } // Внешний ключ для User
    public User User { get; set; } // Навигационное свойство

    public int SkillId { get; set; } // Внешний ключ для Skill
    public Skill Skill { get; set; } // Навигационное свойство
}
