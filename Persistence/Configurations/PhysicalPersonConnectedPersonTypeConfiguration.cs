namespace Persistence.Configurations;

public class PhysicalPersonConnectedPersonTypeConfiguration : IEntityTypeConfiguration<PhysicalPersonConnectedPersonType>
{
    public void Configure(EntityTypeBuilder<PhysicalPersonConnectedPersonType> builder)
    {
          builder.HasKey(x => new { x.PhysicalPersonId, x.ConnectedPersonTypeId });
        
        builder.HasOne(x => x.PhysicalPerson)
        .WithMany(x => x.ConnectedPersonTypes)
        .HasForeignKey(x => x.PhysicalPersonId);
        
        builder.HasOne(x => x.ConnectedPersonType)
            .WithMany(x => x.PhysicalPersons)
            .HasForeignKey(x => x.ConnectedPersonTypeId);
    }
}