namespace Service.Abstractions;

public interface IServiceManager
{
    IPersonService PersonService { get; }
    IRelativeService RelativeService { get; }
}