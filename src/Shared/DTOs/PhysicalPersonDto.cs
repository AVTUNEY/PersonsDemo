namespace Shared.DTOs;

public class PhysicalPersonDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public string City { get; set; }

    public ICollection<PhoneNumberDto> PhoneNumbers { get; set; }

    public string ImagePath { get; set; }

    public ICollection<RelativeDto> Relatives { get; set; }
}