namespace Domain.Entities;

public class PhysicalPerson
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Sex { get; set; }
    
    public string PersonalNumber { get; set; }

    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }

    public List<PhoneNumber> PhoneNumbers { get; set; }

    public string ImagePath { get; set; }
    
    public IEnumerable<ConnectedPersonType> ConnectedPersonTypes { get; set; }
}

public class PhoneNumber
{
    public int Id { get; set; }

    public PhoneNumberType Type { get; set; }
    
    public string Number { get; set; }

    public int PhysicalPersonId { get; set; }
    public PhysicalPerson PhysicalPerson { get; set; }
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum Gender
{
    Female,
    Male
}

public enum PhoneNumberType
{
    Mobile,
    Office,
    Home
}

public class ConnectedPersonType
{
    public int Id { get; set; }
    
    public IEnumerable<PhysicalPerson> PhysicalPersons { get; set; }
}