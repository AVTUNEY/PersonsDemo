namespace Shared.DTOs.PersonConnections;

public class CreatePersonConnectionDto
{
    public int PersonId { get; }
    public int ConnectedPersonId { get; }
    public ConnectionType Type { get; }
}