namespace Shared.Mappings;

public static class PersonMappingExtensions
{
    public static PhysicalPerson PersonDtoToPerson(this CreatePersonDto createPersonDto)
    {
        return new PhysicalPerson
        {
            FirstName = createPersonDto.FirstName,
            LastName = createPersonDto.LastName,
            Gender = createPersonDto.Gender,
            PersonalNumber = createPersonDto.PersonalNumber,
            BirthDate = createPersonDto.BirthDate,
            CityId = createPersonDto.CityId,
            ImagePath = createPersonDto.ImagePath,
            PhoneNumbers = createPersonDto.PhoneNumbers.Select(x => new PhoneNumber
            {
                Number = x.PhoneNumber,
                Type = x.Type
            }).ToList(),
            PersonConnections = createPersonDto.ConnectedPersons.Select(x => new PersonConnection
            {
                ConnectedPersonId = x.ConnectedPersonId,
                ConnectionType = x.ConnectionType
            }).ToList()
        };
    }

    public static PhysicalPersonDto PersonToDto(this PhysicalPerson person, string city)
    {
        return new PhysicalPersonDto(
            Id: person.Id,
            FirstName: person.FirstName,
            LastName: person.LastName,
            BirthDate: person.BirthDate,
            City: city,
            Gender: person.Gender.ToString(),
            PersonalNumber: person.PersonalNumber,
            PhoneNumbers: person.PhoneNumbers.Select(x => new PhoneNumberDto(x.Number, x.Type)).ToList(),
            ImagePath: person.ImagePath,
            ConnectedPersons: person.PersonConnections
                .Select(x => new PersonConnectionDto(x.ConnectedPersonId, x.ConnectionType)).ToList()
        );
    }
    
    public static PhysicalPersonDto MapPersonsDto (this PhysicalPerson person)
    {
        return new PhysicalPersonDto(
            Id: person.Id,
            FirstName: person.FirstName,
            LastName: person.LastName,
            BirthDate: person.BirthDate,
            City: person.City.Name,
            Gender: person.Gender.ToString(),
            PersonalNumber: person.PersonalNumber,
            PhoneNumbers: person.PhoneNumbers.Select(x => new PhoneNumberDto(x.Number, x.Type)).ToList(),
            ImagePath: person.ImagePath,
            ConnectedPersons: person.PersonConnections
                .Select(x => new PersonConnectionDto(x.ConnectedPersonId, x.ConnectionType)).ToList()
        );
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