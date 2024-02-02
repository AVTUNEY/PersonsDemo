using Service.Abstractions;

namespace Services;

public class ServiceManager : IServiceManager
{
    public IPersonService PersonService { get; }
}