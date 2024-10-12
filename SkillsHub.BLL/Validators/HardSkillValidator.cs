using FluentValidation;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Validators;

public class HardSkillValidator : AbstractValidator<HardSkill>
{
    public HardSkillValidator ()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя обязательно")
            .Length(3, 50).WithMessage("Имя должно содержать от 3 до 50 символов");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Описание обязательно")
            .Length(10, 200).WithMessage("Описание должно содержать от 10 до 200 символов");

        RuleFor(x => x.Technology)
            .NotEmpty().WithMessage("Технология обязателен")
            .Length(3, 50).WithMessage("Технология должна содержать от 3 до 50 символов");

        RuleFor(x => x.Level)
            .InclusiveBetween(1, 10).WithMessage("Уровень должен быть от 1 до 10");
    }
}
