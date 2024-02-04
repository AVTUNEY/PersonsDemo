namespace Shared.DTOs.Persons;

public record CreatePersonDto(
    string FirstName,
    string LastName,
    Gender Gender,
    string PersonalNumber,
    DateTime BirthDate,
    int CityId,
    IEnumerable<PhoneNumberDto> PhoneNumbers,
    IEnumerable<PersonConnectionDto> ConnectedPersons,
    string ImagePath
);

public record PersonConnectionDto(
    int? ConnectedPersonId,
    ConnectionType ConnectionType
);

public record ConnectedPersonsDto(
    int? PersonId,
    int? ConnectedPersonId,
    ConnectionType ConnectionType
);

public record PhoneNumberDto(
    string PhoneNumber,
    PhoneNumberType Type
);