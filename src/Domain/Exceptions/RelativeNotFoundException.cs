namespace Domain.Exceptions;

public sealed class RelativeNotFoundException : NotFoundException
{
    public RelativeNotFoundException(int relativeId) : base($"Relative with the identifier {relativeId} was not found.")
    {
    }
}