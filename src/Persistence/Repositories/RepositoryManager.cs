namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IPersonRepository> _lazyPersonRepository;
    private readonly Lazy<IPersonConnectionRepository> _lazyPersonConnectionRepository;
    private readonly Lazy<ICityRepository> _lazyCityRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(TbcDemoDbContext dbContext)
    {
        _lazyPersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(dbContext));
        _lazyPersonConnectionRepository =
            new Lazy<IPersonConnectionRepository>(() => new PersonConnectionRepository(dbContext));
        _lazyCityRepository = new Lazy<ICityRepository>(() => new CityRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }

    public IPersonRepository PersonRepository => _lazyPersonRepository.Value;
    public IPersonConnectionRepository PersonConnectionRepository => _lazyPersonConnectionRepository.Value;
    public ICityRepository CityRepository => _lazyCityRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}