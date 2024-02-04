namespace Domain.Entities;

public class PersonConnection
{
    public int Id { get; set; }
    public int? PersonId { get; set; }
    public PhysicalPerson Person { get; set; }

    public int? ConnectedPersonId { get; set; }
    public PhysicalPerson ConnectedPerson { get; set; }
    public ConnectionType ConnectionType { get; set; }
}