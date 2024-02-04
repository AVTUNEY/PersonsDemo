namespace Domain.Exceptions;

public sealed class PersonConnectionNotFoundException : NotFoundException
{
    public PersonConnectionNotFoundException(int connectionId) : base($"PersonConnection with the identifier {connectionId} was not found.")
    {
    }
}