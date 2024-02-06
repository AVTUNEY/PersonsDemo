namespace Domain.Exceptions;

public sealed class PersonNotFoundException : NotFoundException
{
    public int PersonId { get; set; }

    public PersonNotFoundException(int personId) : base($"The person with the identifier {personId} was not found.")
    {
        PersonId = personId;
    }
}