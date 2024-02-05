using System.ComponentModel.DataAnnotations;

namespace Shared.Validators;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime birthDate)
        {
            if (DateTime.Today.AddYears(-_minimumAge) >= birthDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"The {validationContext.DisplayName} must be at least {_minimumAge} years old.");
            }
        }

        return new ValidationResult("Invalid data type for the BirthDate property.");
    }
}