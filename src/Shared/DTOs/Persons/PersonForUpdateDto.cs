namespace Shared.DTOs.Persons;

public record PersonForUpdateDto(
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
    
    [Required(ErrorMessage = "RequiredErrorMessage")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "PersonalNumberDigitsNumberErrorMessage")]
    [RegularExpression(@"^\d+$", ErrorMessage = "PersonalNumberDigitsOnlyErrorMessage")]
    string PersonalNumber,
    
    [MinimumAge(18, ErrorMessage = "AgeRestrictionErrorMessage")]
    DateTime BirthDate,
    Gender Gender,
    int CityId,
    List<PhoneNumberDto> PhoneNumbers
);