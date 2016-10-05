using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class offreMap : EntityTypeConfiguration<offre>
    {
        public offreMap()
        {
            // Primary Key
            this.HasKey(t => t.idoffre);

            // Properties
            this.Property(t => t.nomOf)
                .HasMaxLength(45);

            this.Property(t => t.descOf)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("offre", "banquedb");
            this.Property(t => t.idoffre).HasColumnName("idoffre");
            this.Property(t => t.nomOf).HasColumnName("nomOf");
            this.Property(t => t.descOf).HasColumnName("descOf");
        }
    }
}
