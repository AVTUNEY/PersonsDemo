namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IPersonService> _lazyPersonService;
    private readonly Lazy<IRelativeService> _lazyRelativeService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager));
        _lazyRelativeService = new Lazy<IRelativeService>(() => new RelativeService(repositoryManager));
    }

    public IPersonService PersonService => _lazyPersonService.Value;
    public IRelativeService RelativeService => _lazyRelativeService.Value;
}