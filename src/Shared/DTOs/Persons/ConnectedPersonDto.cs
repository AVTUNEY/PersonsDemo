namespace Shared.DTOs.Persons;

public class ConnectedPersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class ConnectedPersonsResultDto
{
    public int Count { get; set; }
    public string ConnectionType { get; set; }
    public List<ConnectedPersonDto> ConnectedPersons { get; set; }
}