namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IPersonRepository> _lazyPersonRepository;
    private readonly Lazy<IRelativeRepository> _lazyRelativeRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(TbcDemoDbContext dbContext)
    {
        _lazyPersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(dbContext));
        _lazyRelativeRepository = new Lazy<IRelativeRepository>(() => new RelativeRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }

    public IPersonRepository PersonRepository => _lazyPersonRepository.Value;
    public IRelativeRepository RelativeRepository => _lazyRelativeRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}