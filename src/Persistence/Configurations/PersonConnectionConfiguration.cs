namespace Persistence.Configurations;

public class PersonConnectionConfiguration : IEntityTypeConfiguration<PersonConnection>
{
    public void Configure(EntityTypeBuilder<PersonConnection> builder)
    {
        builder
            .HasKey(pc => pc.Id);
        
        builder.HasIndex(bc => new { bc.PersonId, bc.ConnectedPersonId }).IsUnique();

        builder
            .HasOne(pc => pc.Person)
            .WithMany(p => p.PersonConnections)
            .HasForeignKey(pc => pc.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(pc => pc.ConnectedPerson)
            .WithMany()
            .HasForeignKey(pc => pc.ConnectedPersonId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}