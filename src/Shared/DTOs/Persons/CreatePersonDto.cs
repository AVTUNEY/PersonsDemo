namespace Shared.DTOs.Persons;

public record CreatePersonDto(
    [Required(ErrorMessage = "RequiredErrorMessage")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "StringLengthErrorMessage")]
    [RegularExpression(@"^(([\p{IsGeorgian}]+)|([A-Za-z]+))$",
        ErrorMessage = "InvalidCharactersErrorMessage")]
    string FirstName,
    [Required(ErrorMessage = "RequiredErrorMessage")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "StringLengthErrorMessage")]
    [RegularExpression(@"^(([\p{IsGeorgian}]+)|([A-Za-z]+))$",
        ErrorMessage = "InvalidCharactersErrorMessage")]
    string LastName,
    Gender Gender,
    [Required(ErrorMessage = "RequiredErrorMessage")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "PersonalNumberDigitsNumberErrorMessage")]
    [RegularExpression(@"^\d+$", ErrorMessage = "PersonalNumberDigitsOnlyErrorMessage")]
    string PersonalNumber,
    [MinimumAge(18, ErrorMessage = "AgeRestrictionErrorMessage")]
    DateTime BirthDate,
    int CityId,
    IEnumerable<PhoneNumberDto> PhoneNumbers,
    IEnumerable<PersonConnectionDto> ConnectedPersons,
    string ImagePath
);

public record PhoneNumberDto(
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Phone Number should be between 4 and 50 characters.")]
    string PhoneNumber,
    PhoneNumberType Type
);