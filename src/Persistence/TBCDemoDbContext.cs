namespace Persistence;

public class TbcDemoDbContext : DbContext
{
    public TbcDemoDbContext(DbContextOptions<TbcDemoDbContext> options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
    public DbSet<Relative> Relatives { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TbcDemoDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}