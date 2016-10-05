using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class trainingsessionMap : EntityTypeConfiguration<trainingsession>
    {
        public trainingsessionMap()
        {
            // Primary Key
            this.HasKey(t => t.idTS);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.objective)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("trainingsession", "banquematache");
            this.Property(t => t.idTS).HasColumnName("idTS");
            this.Property(t => t.cout).HasColumnName("cout");
            this.Property(t => t.dateDebut).HasColumnName("dateDebut");
            this.Property(t => t.dateFin).HasColumnName("dateFin");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.objective).HasColumnName("objective");

            // Relationships
            this.HasMany(t => t.trainings)
                .WithMany(t => t.trainingsessions)
                .Map(m =>
                    {
                        m.ToTable("trainingsession_training", "banquematache");
                        m.MapLeftKey("trainSessions_idTS");
                        m.MapRightKey("sessions_idT");
                    });


        }
    }
}
