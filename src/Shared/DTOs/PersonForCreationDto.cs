namespace Shared.DTOs;

public class PersonForCreationDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }

    public string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    public List<PhoneNumberDto> PhoneNumbers { get; set; }
    public List<RelativeDto> Relatives { get; set; }

    public string ImagePath { get; set; }
}

public class RelativeDto
{
    public int RelatedPersonId { get; set; }

    public RelationshipType RelationshipType { get; set; }
}

public class PhoneNumberDto
{
    public string PhoneNumber { get; set; }
    public PhoneNumberType Type { get; set; }
}