using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SkillsHubV2.Web.Models;

public class SkillViewModel : IValidatableObject
{
    [Required(ErrorMessage = "")]
    public string Name { get; set; }

    private readonly ISkillsService<SoftSkill> _service;

    public SkillViewModel (ISkillsService<SoftSkill> service)
    {
        _service = service;
    }

    public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
    {
        if (_service.IsNameTakenAsync(Name).Result)
        {
            yield return new ValidationResult("Name is taken.", ["Name"]);
        }
    }
}
