namespace Service.Abstractions;

public interface IServiceManager
{
    IPersonService PersonService { get; }
    IPersonConnectionService PersonConnectionService { get; }
}