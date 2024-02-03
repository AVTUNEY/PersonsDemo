namespace Persistence.Configurations;

public class RelativeConfiguration : IEntityTypeConfiguration<Relative>
{
    public void Configure(EntityTypeBuilder<Relative> builder)
    {
        builder.HasKey(m => m.Id);  
        
        builder.HasOne(bc => bc.Person)
               .WithMany()
               .HasForeignKey(bc => bc.PersonId)
               .OnDelete(DeleteBehavior.Restrict);  
        
        builder.HasOne(bc => bc.RelatedPerson)
            .WithMany()
            .HasForeignKey(bc => bc.RelatedPersonId)
            .OnDelete(DeleteBehavior.Restrict); 
        
    }
}