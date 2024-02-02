using Domain.Repositories;
using Service.Abstractions;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPersonService> _lazyPersonService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager));
    }

    public IPersonService PersonService => _lazyPersonService.Value;
}