namespace Shared.DTOs.PersonConnections;

public class CreatePersonConnectionDto
{
    public int PersonId { get; set; }
    public int ConnectedPersonId { get; set; }
    public ConnectionType Type { get; set; }
}