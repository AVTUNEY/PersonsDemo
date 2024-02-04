namespace Domain.Exceptions;

public sealed class PersonNotFoundException : NotFoundException
{
    public PersonNotFoundException(int personId) : base($"The person with the identifier {personId} was not found.")
    {
    }
}