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
    
    
    // public static void SeedData(IServiceProvider serviceProvider)
    // {
    //     using (var context =
    //            new TbcDemoDbContext(serviceProvider.GetRequiredService<DbContextOptions<TbcDemoDbContext>>()))
    //     {
    //         // Check if data already exists
    //         if (context.PhysicalPersons.Any())
    //         {
    //             return; // Data already seeded
    //         }
    //
    //         // Seed Gender enum values
    //         var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
    //
    //         // Seed PhoneNumberType enum values
    //         var phoneNumberTypes = Enum.GetValues(typeof(PhoneNumberType)).Cast<PhoneNumberType>().ToList();
    //
    //         // Seed City data
    //         var cities = new List<City>
    //         {
    //             new City { Id = 1, Name = "Tbilisi" },
    //             new City { Id = 2, Name = "Batumi" },
    //             // Add more cities as needed
    //         };
    //
    //         context.Cities.AddRange(cities);
    //         context.SaveChanges();
    //
    //         // Seed PhysicalPerson data
    //         var persons = new List<PhysicalPerson>
    //         {
    //             new PhysicalPerson
    //             {
    //                 Id = 1,
    //                 FirstName = "John",
    //                 LastName = "Doe",
    //                 Sex = Gender.Male,
    //                 PersonalNumber = "123456789",
    //                 BirthDate = new DateTime(1990, 1, 1),
    //                 ImagePath = "john.jpg",
    //                 City = cities[0] // City1
    //             },
    //             new PhysicalPerson
    //             {
    //                 Id = 2,
    //                 FirstName = "Alice",
    //                 LastName = "Smith",
    //                 Sex = Gender.Female,
    //                 PersonalNumber = "987654321",
    //                 BirthDate = new DateTime(1995, 5, 5),
    //                 ImagePath = "alice.jpg",
    //                 City = cities[1], // City1
    //             },
    //             new PhysicalPerson
    //             {
    //                 Id = 3,
    //                 FirstName = "Bob",
    //                 LastName = "Johnson",
    //                 Sex = Gender.Male,
    //                 PersonalNumber = "555555555",
    //                 BirthDate = new DateTime(1985, 10, 10),
    //                 ImagePath = "bob.jpg",
    //                 City = cities[2] // City1
    //             },
    //         };
    //
    //         context.PhysicalPersons.AddRange(persons);
    //         context.SaveChanges();
    //
    //         // Seed PhoneNumber data
    //         var phoneNumbers = new List<PhoneNumber>
    //         {
    //             new PhoneNumber
    //             {
    //                 Id = 1, Type = PhoneNumberType.Mobile, Number = "123-456-7890", PhysicalPersonId = 1
    //             }, // John's phone number
    //             new PhoneNumber
    //             {
    //                 Id = 2, Type = PhoneNumberType.Office, Number = "987-654-3210", PhysicalPersonId = 2
    //             }, // Alice's phone number
    //             new PhoneNumber
    //             {
    //                 Id = 3, Type = PhoneNumberType.Home, Number = "555-555-5555", PhysicalPersonId = 3
    //             }, // Bob's phone number
    //             // Add more phone numbers as needed
    //         };
    //
    //         context.PhoneNumbers.AddRange(phoneNumbers);
    //         context.SaveChanges();
    //
    //         // Seed Relative data
    //         var relatives = new List<Relative>
    //         {
    //             new Relative
    //             {
    //                 RelativeId = 1, PersonId = 1, RelatedPersonId = 2, RelationshipType = "Friend"
    //             }, // John is friends with Alice
    //             new Relative
    //             {
    //                 RelativeId = 2, PersonId = 2, RelatedPersonId = 3, RelationshipType = "Colleague"
    //             }, // Alice is colleagues with Bob
    //             // Add more relatives as needed
    //         };
    //
    //         context.Relatives.AddRange(relatives);
    //         context.SaveChanges();
    //     }
    // }
}