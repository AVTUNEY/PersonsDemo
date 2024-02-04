namespace Persistence.Configurations;

public class RelativeConfiguration : IEntityTypeConfiguration<Relative>
{
    public void Configure(EntityTypeBuilder<Relative> builder)
    {
        builder.HasKey(m => m.Id);  
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
       builder
            .HasOne(r => r.Person)
            .WithMany(p => p.Relatives)
            .HasForeignKey(r => r.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(r => r.RelatedPerson)
            .WithMany(p => p.RelatedPersonRelatives)
            .HasForeignKey(r => r.RelatedPersonId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(bc => new { bc.PersonId, bc.RelatedPersonId }).IsUnique();
    }
}