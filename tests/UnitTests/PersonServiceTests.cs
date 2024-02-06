namespace UnitTests;

public class PersonServiceTests
{
    private Mock<IRepositoryManager> _repositoryManagerMock;
    private Mock<IHostEnvironment> _hostEnvironmentMock;
    private PersonService _personService;

    [SetUp]
    public void SetUp()
    {
        _repositoryManagerMock = new Mock<IRepositoryManager>();
        _hostEnvironmentMock = new Mock<IHostEnvironment>();

        _personService = new PersonService(_repositoryManagerMock.Object, _hostEnvironmentMock.Object);
    }

    [Test]
    public async Task CreateAsync_ValidData_CreatesPersonAndReturnsDto()
    {
        // Arrange
        var createPersonDto = new CreatePersonDto(
            "John",
            "Doe",
            Gender.Male,
            "12345678901",
            new DateTime(1990, 1, 1),
            1,
            new List<PhoneNumberDto>
            {
                new PhoneNumberDto("123456789", PhoneNumberType.Mobile)
            },
            new List<PersonConnectionDto>(),
            "john.jpg"
        );
        
        var city = new City
        {
            Id = 1,
            Name = "Tbilisi"
        };

        _repositoryManagerMock.Setup(rm =>
                rm.CityRepository.GetSingleByCondition(It.IsAny<Expression<Func<City, bool>>>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(city);

        _repositoryManagerMock.Setup(rm => rm.PersonRepository.Create(It.IsAny<PhysicalPerson>()));
        _repositoryManagerMock.Setup(rm => rm.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await _personService.CreateAsync(createPersonDto, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.FirstName, Is.EqualTo(createPersonDto.FirstName));
    }
}