using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class candidatureMap : EntityTypeConfiguration<candidature>
    {
        public candidatureMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.CandidateName)
                .HasMaxLength(10);

            this.Property(t => t.Cv)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("candidatures", "banquedb");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.CandidateName).HasColumnName("CandidateName");
            this.Property(t => t.Cv).HasColumnName("Cv");
        }
    }
}
