using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Configurations;

public class PhysicalPersonConfiguration : IEntityTypeConfiguration<PhysicalPerson>
{
    public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50).IsUnicode();

        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50).IsUnicode();

        builder.Property(p => p.Gender).IsRequired();

        builder.Property(p => p.PersonalNumber).IsRequired().HasMaxLength(11);

        builder.Property(p => p.BirthDate)
            .IsRequired()
            .HasColumnType("date")
            .HasConversion(new ValueConverter<DateTime, DateTime>(
                v => v,
                v => ValidateBirthDate(v)));

        builder.Property(p => p.ImagePath).HasMaxLength(255);

        builder.HasOne(p => p.City)
            .WithMany()
            .HasForeignKey(p => p.CityId)
            .IsRequired();

        builder.HasMany(p => p.PhoneNumbers)
            .WithOne(pn => pn.PhysicalPerson)
            .HasForeignKey(pn => pn.PhysicalPersonId);
    }

    private DateTime ValidateBirthDate(DateTime birthDate)
    {
        if (birthDate > DateTime.Now.AddYears(-18))
        {
            throw new ArgumentOutOfRangeException("BirthDate must be more than 18 years ago.");
        }

        return birthDate;
    }
}