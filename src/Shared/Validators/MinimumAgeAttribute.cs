namespace Shared.Validators;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;
    private readonly IStringLocalizer<SharedResource> _stringLocaliser;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;

        var options = Options.Create(new LocalizationOptions());
        var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
        var stringLocaliser = new StringLocalizer<SharedResource>(factory);

        _stringLocaliser = stringLocaliser;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime birthDate)
        {
            if (DateTime.Today.AddYears(-_minimumAge) >= birthDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                var errorMessage = _stringLocaliser["AgeRestrictionErrorMessage"];
                return new ValidationResult(errorMessage);
            }
        }

        return new ValidationResult(_stringLocaliser["InvalidDataTypeForDate"]);
    }
}