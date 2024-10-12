using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SkillsHubV2.Domain.Entities;

public abstract class Skill // Базовый класс для TPT
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string? Name { get; set; }

    [AllowNull]
    [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
    public string? Description { get; set; }
}
