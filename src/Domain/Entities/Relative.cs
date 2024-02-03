namespace Domain.Entities;

public class Relative
{
    public int Id { get; set; }
    // Foreign key to the main person
    public int PersonId { get; set; }
    public PhysicalPerson Person { get; set; }

    // Foreign key to the related person
    public int RelatedPersonId { get; set; }
    public PhysicalPerson RelatedPerson { get; set; }

    public RelationshipType RelationshipType { get; set; }
}