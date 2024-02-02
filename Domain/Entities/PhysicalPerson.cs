namespace Domain.Entities;

public class PhysicalPerson
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Sex { get; set; }
    
    public string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public City City { get; set; }

    public ICollection<PhoneNumber> PhoneNumbers { get; set; }

    public string ImagePath { get; set; }
    
    public ICollection<PhysicalPersonConnectedPersonType> ConnectedPersonTypes { get; set; }
}