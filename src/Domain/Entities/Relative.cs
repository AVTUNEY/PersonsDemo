namespace Domain.Entities;

public class Relative
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public PhysicalPerson Person { get; set; }
    public int RelatedPersonId { get; set; }
    public PhysicalPerson RelatedPerson { get; set; }

    public RelationshipType RelationshipType { get; set; }
}