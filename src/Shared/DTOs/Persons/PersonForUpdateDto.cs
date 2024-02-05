using System.ComponentModel.DataAnnotations;
using Shared.Validators;

namespace Shared.DTOs.Persons;

public record PersonForUpdateDto(
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name should be between 2 and 50 characters.")]
    [RegularExpression(@"^(([\p{IsGeorgian}]+)|([A-Za-z]+))$",
        ErrorMessage = "First name should only contain either Georgian or English alphabet characters.")]
    string FirstName,
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name should be between 2 and 50 characters.")]
    [RegularExpression(@"^(([\p{IsGeorgian}]+)|([A-Za-z]+))$",
        ErrorMessage = "Last name should only contain either Georgian or English alphabet characters.")]
    string LastName,
    Gender Gender,
    [Required(ErrorMessage = "Personal Number is required.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Personal Number should contain 11 digit")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Personal Number should only contain digits")]
    string PersonalNumber,
    [MinimumAge(18, ErrorMessage = "You must be at least 18 years old.")]
    DateTime BirthDate,
    int CityId,
    List<PhoneNumberDto> PhoneNumbers
);