namespace Shared.DTOs;

public class RelativeForCreationDto
{
    public int PersonId { get; set; }
    public int RelativeId { get; set; }
    public RelationshipType Type { get; set; }
}