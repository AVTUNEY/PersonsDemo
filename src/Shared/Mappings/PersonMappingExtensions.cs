namespace Shared.Mappings;

public static class PersonMappingExtensions
{
    public static PhysicalPerson PersonDtoToPerson(this PersonForCreationDto personForCreationDto)
    {
        return new PhysicalPerson
        {
            FirstName = personForCreationDto.FirstName,
            LastName = personForCreationDto.LastName,
            Gender = personForCreationDto.Gender,
            PersonalNumber = personForCreationDto.PersonalNumber,
            BirthDate = personForCreationDto.BirthDate,
            CityId = personForCreationDto.CityId,
            ImagePath = personForCreationDto.ImagePath,
            PhoneNumbers = personForCreationDto.PhoneNumbers?.Select(phone => new PhoneNumber
            {
                Number = phone.PhoneNumber,
                Type = phone.Type
            }).ToList(),
            Relatives = personForCreationDto.Relatives?.Select(relative => new Relative
            {
                RelatedPersonId = relative.RelatedPersonId,
                RelationshipType = relative.RelationshipType
            }).ToList()
        };
    }

    public static PhysicalPersonDto PersonToDto(this PhysicalPerson person)
    {
        return new PhysicalPersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            BirthDate = person.BirthDate,
            City = person.City?.Name,
            Gender = person.Gender.ToString(),
            PersonalNumber = person.PersonalNumber,
            PhoneNumbers = person.PhoneNumbers.Select(phone => new PhoneNumberDto
            {
                PhoneNumber = phone.Number,
                Type = phone.Type
            }).ToList(),
            Relatives = person.Relatives?.Select(relative => new RelativeDto
            {
                RelatedPersonId = relative.RelatedPersonId,
                RelationshipType = relative.RelationshipType
            }).ToList()
        };
    }
    
    public static void UpdateFromDto(this PhysicalPerson person, PersonForUpdateDto updatedPersonDto)
    {
        if (person == null || updatedPersonDto == null)
            return;

        person.FirstName = updatedPersonDto.FirstName;
        person.LastName = updatedPersonDto.LastName;
        person.Gender = updatedPersonDto.Gender;
        person.PersonalNumber = updatedPersonDto.PersonalNumber;
        person.BirthDate = updatedPersonDto.BirthDate;
        person.CityId = updatedPersonDto.CityId;

        // Update PhoneNumbers (replace existing PhoneNumbers with the new ones)
        person.PhoneNumbers = updatedPersonDto.PhoneNumbers?.Select(phone => new PhoneNumber
        {
            Number = phone.PhoneNumber,
            Type = phone.Type
        }).ToList();
    }
}