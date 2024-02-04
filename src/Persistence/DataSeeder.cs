using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DataSeeder
{
    public static void CitySeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>()
            .HasData(
                new List<City>()
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
                }
            );
    }

    public static void PhysicalPersonSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhysicalPerson>()
            .HasData(new List<PhysicalPerson>()
            {
                new PhysicalPerson
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Sex = Gender.Male,
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
                    Sex = Gender.Female,
                    PersonalNumber = "987654321",
                    BirthDate = new DateTime(1995, 5, 5),
                    ImagePath = "alice.jpg",
                    CityId = 2
                },
            });
    }

    public static void PhoneNumbersSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneNumber>().HasData(new List<PhoneNumber>()
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
        });
    }

    public static void RelativeSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Relative>()
            .HasData(new List<Relative>()
            {
                new Relative()
                {
                    Id = 1,
                    PersonId = 1,
                    RelatedPersonId = 2,
                    RelationshipType = RelationshipType.Friend
                }
            });
    }
}