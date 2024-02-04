namespace Shared.DTOs.Persons;

public record PhysicalPersonDto(
    int Id,
    string FirstName,
    string LastName,
    string Gender,
    string PersonalNumber,
    DateTime BirthDate,
    string City,
    string ImagePath,
    ICollection<PhoneNumberDto> PhoneNumbers,
    ICollection<PersonConnectionDto> ConnectedPersons
);