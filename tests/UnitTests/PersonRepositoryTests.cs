namespace UnitTests;

public class PersonRepositoryTests
{
    private DbContextOptions<TbcDemoDbContext> _options;
    private TbcDemoDbContext _dbContext;
    private PersonRepository _personRepository;

    [SetUp]
    public void SetUp()
    {
        _options = new DbContextOptionsBuilder<TbcDemoDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        
        _dbContext = new TbcDemoDbContext(_options);
        _dbContext.PhysicalPersons.AddRange(DataSeeder.SeedPhysicalPersons());
        _dbContext.PhoneNumbers.AddRange(DataSeeder.SeedPhoneNumbers());
        _dbContext.PersonConnections.AddRange(DataSeeder.SeedPersonConnections());
        _dbContext.Cities.AddRange(DataSeeder.SeedCities());
        _dbContext.SaveChangesAsync();

        _personRepository = new PersonRepository(_dbContext);
    }

    [Test]
    public async Task GetAllAsync_ReturnsAllPhysicalPersons()
    {
        // Act
        var result = await _personRepository.GetAllAsync();

        // Assert
        var physicalPersons = result as PhysicalPerson[] ?? result.ToArray();

        Assert.That(physicalPersons.Count(), Is.EqualTo(6));
    }

    [Test]
    public async Task GetByIdAsync_ReturnsPhysicalPersonWithGivenId()
    {
        // Arrange
        var expectedId = 1;
        var expectedFirstName = "John";
        var expectedLastName = "Doe";

        // Act
        var result = await _personRepository.GetByIdAsync(expectedId);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Id, Is.EqualTo(expectedId));
        Assert.That(result.FirstName, Is.EqualTo(expectedFirstName));
        Assert.That(result.LastName, Is.EqualTo(expectedLastName));
    }

    [Test]
    public void Search_ReturnsPhysicalPersonsMatchingSearchTerm()
    {
        // Arrange
        var searchTerm = "John";
        var expectedCount = 4;

        // Act
        var result = _personRepository.Search(searchTerm);
        var physicalPersons = result.ToList();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(physicalPersons.Count(), Is.EqualTo(expectedCount));
        Assert.IsTrue(physicalPersons.All(p =>
            p.FirstName.Contains(searchTerm) || p.LastName.Contains(searchTerm) ||
            p.PersonalNumber.Contains(searchTerm)));
    }

    [Test]
    public void DetailedSearch_ReturnsMatchingPhysicalPersons()
    {
        // Arrange
        var expectedCount = 1;
        var firstName = "John";
        var lastName = "Doe";
        var personalNumber = "123456789";

        // Act
        var result = _personRepository.DetailedSearch(firstName, lastName, personalNumber);
        var physicalPersons = result.ToList();
        var firstPerson = physicalPersons.FirstOrDefault();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(physicalPersons.Count(), Is.EqualTo(expectedCount));
        Assert.IsNotNull(firstPerson);
        Assert.That(firstPerson?.FirstName, Is.EqualTo(firstName));
        Assert.That(firstPerson?.LastName, Is.EqualTo(lastName));
        Assert.That(firstPerson?.PersonalNumber, Is.EqualTo(personalNumber));
    }

    [Test]
    public void GetConnectedPersonsByType_ReturnsCorrectConnectedPersons()
    {
        // Arrange
        var targetPersonId = 3;
        var connectionType = ConnectionType.Friend;

        // Act
        var result = _personRepository.GetConnectedPersonsByType(targetPersonId, connectionType);

        // Assert
        Assert.IsNotNull(result);
    }
}