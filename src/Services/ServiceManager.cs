namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPersonService> _lazyPersonService;
    private readonly Lazy<IPersonConnectionService> _lazyRelativeService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager));
        _lazyRelativeService = new Lazy<IPersonConnectionService>(() => new PersonConnectionService(repositoryManager));
    }

    public IPersonService PersonService => _lazyPersonService.Value;
    public IPersonConnectionService PersonConnectionService => _lazyRelativeService.Value;
}