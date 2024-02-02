namespace Domain.Entities;

public class ConnectedPersonType
{
    public int Id { get; set; }
    public string ConnectionType { get; set; }
    
    public ICollection<PhysicalPersonConnectedPersonType> PhysicalPersons { get; set; }
}