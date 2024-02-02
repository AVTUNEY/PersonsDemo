namespace Persistence.Configurations;

public class ConnectedPersonTypeConfiguration : IEntityTypeConfiguration<ConnectedPersonType>
{
    public void Configure(EntityTypeBuilder<ConnectedPersonType> builder)
    {
        builder.HasKey(x => x.Id);
    }
}