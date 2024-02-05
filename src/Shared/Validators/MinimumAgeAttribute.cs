namespace Shared.Validators;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;

        var options = Options.Create(new LocalizationOptions());
        var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
        var localizer = new StringLocalizer<SharedResource>(factory);

        _localizer = localizer;
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
                var errorMessage = _localizer["AgeRestrictionErrorMessage"];
                return new ValidationResult(errorMessage);
            }
        }

        return new ValidationResult("Invalid data type for the BirthDate property.");
    }
}