namespace UnitTests;

internal static class DataSeeder
{
    internal static List<PersonConnection> SeedPersonConnections()
    {
        var connections = new List<PersonConnection>()
        {
            new PersonConnection()
            {
                Id = 1,
                PersonId = 1,
                ConnectedPersonId = 2,
                ConnectionType = ConnectionType.Friend
            },
            new PersonConnection()
            {
                Id = 2,
                PersonId = 3,
                ConnectedPersonId = 4,
                ConnectionType = ConnectionType.Collegue
            },
            new PersonConnection()
            {
                Id = 3,
                PersonId = 3,
                ConnectedPersonId = 1,
                ConnectionType = ConnectionType.Relative
            }
        };

        return connections;
    }

    internal static List<City> SeedCities()
    {
        var cities = new List<City>()
        {
            new City()
            {
                Id = 1,
                Name = "Tbilisi"
            },
            new City()
            {
                Id = 2,
                Name = "Batumi"
            },
            new City()
            {
                Id = 3,
                Name = "Gori"
            }
        };
        return cities;
    }

    internal static List<PhysicalPerson> SeedPhysicalPersons()
    {
        var physicalPersons = new List<PhysicalPerson>
        {
            new PhysicalPerson
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = Gender.Male,
                    PersonalNumber = "123456789",
                    BirthDate = new DateTime(1990, 1, 1),
                    ImagePath = "john.jpg",
                    CityId = 1,
                },
                new PhysicalPerson
                {
                    Id = 2,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    PersonalNumber = "987654321",
                    BirthDate = new DateTime(1995, 5, 5),
                    ImagePath = "alice.jpg",
                    CityId = 2
                },
                new PhysicalPerson
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Gender = Gender.Male,
                    PersonalNumber = "555555555",
                    BirthDate = new DateTime(1985, 8, 15),
                    ImagePath = "bob.jpg",
                    CityId = 3
                },
                new PhysicalPerson
                {
                    Id = 4,
                    FirstName = "Eva",
                    LastName = "Brown",
                    Gender = Gender.Female,
                    PersonalNumber = "111111111",
                    BirthDate = new DateTime(1980, 12, 10),
                    ImagePath = "eva.jpg",
                    CityId = 1
                },
                new PhysicalPerson
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Smith",
                    Gender = Gender.Male,
                    PersonalNumber = "555123123",
                    BirthDate = new DateTime(1992, 3, 20),
                    ImagePath = "john_smith.jpg",
                    CityId = 2
                },
                new PhysicalPerson
                {
                    Id = 6,
                    FirstName = "John",
                    LastName = "Williams",
                    Gender = Gender.Male,
                    PersonalNumber = "999888777",
                    BirthDate = new DateTime(1987, 7, 8),
                    ImagePath = "john_williams.jpg",
                    CityId = 3
                },
        };
        return physicalPersons;
    }
    
    internal static List<PhoneNumber> SeedPhoneNumbers()
    {
        var phoneNumbers = new List<PhoneNumber>()
        {
            new PhoneNumber()
            {
                Id = 1,
                Number = "24324",
                Type = PhoneNumberType.Home,
                PhysicalPersonId = 1
            },
            new PhoneNumber()
            {
                Id = 2,
                Number = "123",
                Type = PhoneNumberType.Mobile,
                PhysicalPersonId = 1
            },
            new PhoneNumber()
            {
                Id = 3,
                Number = "54543",
                Type = PhoneNumberType.Office,
                PhysicalPersonId = 2
            },
            new PhoneNumber()
            {
                Id = 4,
                Number = "437",
                Type = PhoneNumberType.Mobile,
                PhysicalPersonId = 2
            }
        };
        return phoneNumbers;
    }
}