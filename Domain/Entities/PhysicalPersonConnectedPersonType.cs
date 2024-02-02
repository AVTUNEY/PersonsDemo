namespace Domain.Entities;

public class PhysicalPersonConnectedPersonType
{
    public int PhysicalPersonId { get; set; }
    public PhysicalPerson PhysicalPerson { get; set; }
    public int ConnectedPersonTypeId { get; set; }
    public ConnectedPersonType ConnectedPersonType { get; set; }
}