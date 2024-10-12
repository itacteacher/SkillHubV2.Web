using System.ComponentModel.DataAnnotations;

namespace SkillsHubV2.Domain.Validators;

public class NoPalindromeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid (object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        string inputValue = value.ToString();

        string reversedValue = new string(inputValue.Reverse().ToArray());

        if (inputValue.Equals(reversedValue, StringComparison.OrdinalIgnoreCase))
        {
            return new ValidationResult("Значение не должно быть палиндромом.");
        }

        return ValidationResult.Success;
    }
}