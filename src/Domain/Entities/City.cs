namespace Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PhysicalPersonId { get; set; }
    public PhysicalPerson PhysicalPerson { get; set; }
}