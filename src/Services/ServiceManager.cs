namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPersonService> _lazyPersonService;
    private readonly Lazy<IPersonConnectionService> _lazyPersonConnectionService;

    public ServiceManager(IRepositoryManager repositoryManager,IHostEnvironment environment)
    {
        _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager,environment));
        _lazyPersonConnectionService = new Lazy<IPersonConnectionService>(() => new PersonConnectionService(repositoryManager));
    }

    public IPersonService PersonService => _lazyPersonService.Value;
    public IPersonConnectionService PersonConnectionService => _lazyPersonConnectionService.Value;
}