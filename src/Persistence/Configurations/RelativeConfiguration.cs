namespace Persistence.Configurations;

public class RelativeConfiguration : IEntityTypeConfiguration<Relative>
{
    public void Configure(EntityTypeBuilder<Relative> builder)
    {
        builder.HasKey(m => m.Id);  
        
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(bc => bc.Person)
               .WithMany(r => r.Relatives)
               .HasForeignKey(bc => bc.PersonId)
               .OnDelete(DeleteBehavior.Cascade);  
        
        builder.HasOne(bc => bc.RelatedPerson)
            .WithMany()
            .HasForeignKey(bc => bc.RelatedPersonId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        builder.HasIndex(bc => new { bc.PersonId, bc.RelatedPersonId }).IsUnique();
    }
}