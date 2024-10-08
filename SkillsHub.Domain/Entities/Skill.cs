using System.ComponentModel.DataAnnotations;

namespace SkillsHubV2.Domain.Entities;

public abstract class Skill // Базовый класс для TPT
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
