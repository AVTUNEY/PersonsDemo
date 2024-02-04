namespace Shared.DTOs;

public record PersonForUpdateDto(
    string FirstName,
    string LastName,
    Gender Gender,
    string PersonalNumber,
    DateTime BirthDate,
    int CityId,
    List<PhoneNumberDto> PhoneNumbers
);