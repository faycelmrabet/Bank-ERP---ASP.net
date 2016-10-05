using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class trainingMap : EntityTypeConfiguration<training>
    {
        public trainingMap()
        {
            // Primary Key
            this.HasKey(t => t.idT);

            // Properties
            this.Property(t => t.idT)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lieu)
                .HasMaxLength(255);

            this.Property(t => t.theme)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("training", "banquematache");
            this.Property(t => t.idT).HasColumnName("idT");
            this.Property(t => t.dateDebut).HasColumnName("dateDebut");
            this.Property(t => t.dateFin).HasColumnName("dateFin");
            this.Property(t => t.lieu).HasColumnName("lieu");
            this.Property(t => t.nombreInscrit).HasColumnName("nombreInscrit");
            this.Property(t => t.theme).HasColumnName("theme");

            // Relationships
            this.HasMany(t => t.utilisateurs)
                .WithMany(t => t.trainings)
                .Map(m =>
                    {
                        m.ToTable("training_utilisateur", "banquematache");
                        m.MapLeftKey("trainings_idT");
                        m.MapRightKey("trainers_idUser");
                    });


        }
    }
}
