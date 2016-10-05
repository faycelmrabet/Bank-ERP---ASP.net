using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class materielMap : EntityTypeConfiguration<materiel>
    {
        public materielMap()
        {
            // Primary Key
            this.HasKey(t => t.idM);

            // Properties
            this.Property(t => t.idM)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.path)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("materiels", "banquedb");
            this.Property(t => t.idM).HasColumnName("idM");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.id_F).HasColumnName("id_F");
            this.Property(t => t.path).HasColumnName("path");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.qte).HasColumnName("qte");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.admin_idUser).HasColumnName("admin_idUser");

            // Relationships
            this.HasOptional(t => t.utilisateur)
                .WithMany(t => t.materiels)
                .HasForeignKey(d => d.admin_idUser);

        }
    }
}
