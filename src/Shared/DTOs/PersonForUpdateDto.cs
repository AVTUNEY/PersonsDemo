namespace Shared.DTOs;

public class PersonForUpdateDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }

    public string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    public List<PhoneNumberDto> PhoneNumbers { get; set; }
}