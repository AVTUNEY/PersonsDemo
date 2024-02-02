namespace Shared;

public class PhysicalPersonDto
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public string City { get; set; }

    public ICollection<string> PhoneNumbers { get; set; }

    public string ImagePath { get; set; }

    // Assuming you only want to expose the connected person types' ids in the DTO
    public ICollection<int> ConnectedPersonTypeIds { get; set; }
}