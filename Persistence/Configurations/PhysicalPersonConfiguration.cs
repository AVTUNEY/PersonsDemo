namespace Persistence.Configurations;

public class PhysicalPersonConfiguration : IEntityTypeConfiguration<PhysicalPerson>
{
    public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50).IsUnicode();

        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50).IsUnicode();

        builder.Property(p => p.Sex).IsRequired();

        builder.Property(p => p.PersonalNumber).IsRequired().HasMaxLength(11);

        builder.Property(p => p.BirthDate).IsRequired().HasColumnType("date");

        builder.HasOne(p => p.City).WithOne(x => x.PhysicalPerson).HasForeignKey<City>(p => p.PhysicalPersonId)
            .IsRequired();

        builder.HasMany(p => p.PhoneNumbers)
            .WithOne(pn => pn.PhysicalPerson)
            .HasForeignKey(pn => pn.PhysicalPersonId);

        builder.Property(p => p.ImagePath).HasMaxLength(255);
    }
}