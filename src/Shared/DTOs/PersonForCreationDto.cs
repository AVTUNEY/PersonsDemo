namespace Shared.DTOs;

public record PersonForCreationDto(
    string FirstName,
    string LastName,
    Gender Gender,
    string PersonalNumber,
    DateTime BirthDate,
    int CityId,
    List<PhoneNumberDto> PhoneNumbers,
    List<RelativeDto> Relatives,
    string ImagePath
);

public record RelativeDto(
    int RelatedPersonId,
    RelationshipType RelationshipType
);

public record PhoneNumberDto(
    string PhoneNumber,
    PhoneNumberType Type
);