namespace Shared.DTOs.Persons;

public class ConnectedPersonInfoDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class ConnectedPersonsResult
{
    public int Count { get; set; }
    public string ConnectionType { get; set; } = null!;
    public List<ConnectedPersonInfoDto> ConnectedPersons { get; set; } = new List<ConnectedPersonInfoDto>();
}