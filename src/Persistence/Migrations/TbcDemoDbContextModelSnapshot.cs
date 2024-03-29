﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(TbcDemoDbContext))]
    partial class TbcDemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Batumi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gori"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PersonConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConnectedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("ConnectionType")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConnectedPersonId");

                    b.HasIndex("PersonId", "ConnectedPersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL AND [ConnectedPersonId] IS NOT NULL");

                    b.ToTable("PersonConnections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConnectedPersonId = 2,
                            ConnectionType = 2,
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConnectedPersonId = 4,
                            ConnectionType = 1,
                            PersonId = 3
                        },
                        new
                        {
                            Id = 3,
                            ConnectedPersonId = 1,
                            ConnectionType = 3,
                            PersonId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhysicalPersonId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhysicalPersonId");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "24324",
                            PhysicalPersonId = 1,
                            Type = 3
                        },
                        new
                        {
                            Id = 2,
                            Number = "123",
                            PhysicalPersonId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Number = "54543",
                            PhysicalPersonId = 2,
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Number = "437",
                            PhysicalPersonId = 2,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.PhysicalPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PhysicalPersons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityId = 1,
                            FirstName = "John",
                            Gender = 2,
                            ImagePath = "john.jpg",
                            LastName = "Doe",
                            PersonalNumber = "123456789"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityId = 2,
                            FirstName = "Alice",
                            Gender = 1,
                            ImagePath = "alice.jpg",
                            LastName = "Smith",
                            PersonalNumber = "987654321"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1985, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityId = 3,
                            FirstName = "Bob",
                            Gender = 2,
                            ImagePath = "bob.jpg",
                            LastName = "Johnson",
                            PersonalNumber = "555555555"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1980, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityId = 1,
                            FirstName = "Eva",
                            Gender = 1,
                            ImagePath = "eva.jpg",
                            LastName = "Brown",
                            PersonalNumber = "111111111"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1992, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityId = 2,
                            FirstName = "John",
                            Gender = 2,
                            ImagePath = "john_smith.jpg",
                            LastName = "Smith",
                            PersonalNumber = "555123123"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1987, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CityId = 3,
                            FirstName = "John",
                            Gender = 2,
                            ImagePath = "john_williams.jpg",
                            LastName = "Williams",
                            PersonalNumber = "999888777"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PersonConnection", b =>
                {
                    b.HasOne("Domain.Entities.PhysicalPerson", "ConnectedPerson")
                        .WithMany()
                        .HasForeignKey("ConnectedPersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.PhysicalPerson", "Person")
                        .WithMany("PersonConnections")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ConnectedPerson");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("Domain.Entities.PhysicalPerson", "PhysicalPerson")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PhysicalPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhysicalPerson");
                });

            modelBuilder.Entity("Domain.Entities.PhysicalPerson", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.Entities.PhysicalPerson", b =>
                {
                    b.Navigation("PersonConnections");

                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
