namespace Persistence.Configurations;

public class PersonConnectionConfiguration : IEntityTypeConfiguration<PersonConnection>
{
    public void Configure(EntityTypeBuilder<PersonConnection> builder)
    {
        builder
            .HasKey(pc => pc.Id);

        builder
            .HasOne(pc => pc.Person)
            .WithMany(p => p.PersonConnections)
            .HasForeignKey(pc => pc.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(pc => pc.ConnectedPerson)
            .WithMany() // Omit the navigation property here since it's not explicitly declared in PersonConnection
            .HasForeignKey(pc => pc.ConnectedPersonId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(bc => new { bc.PersonId, bc.ConnectedPersonId }).IsUnique();
    }
}