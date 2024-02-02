namespace Domain.Entities;

public class ConnectedPersonType
{
    public int Id { get; set; }
    
    public IEnumerable<PhysicalPerson> PhysicalPersons { get; set; }
}