namespace Persistence.Configurations;

public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.HasKey(pn => pn.Id);
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(pn => pn.Type).IsRequired();

        builder.Property(pn => pn.Number).IsRequired().HasMaxLength(50);
    }
}