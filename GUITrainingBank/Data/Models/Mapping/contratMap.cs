using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class contratMap : EntityTypeConfiguration<contrat>
    {
        public contratMap()
        {
            // Primary Key
            this.HasKey(t => t.idContrat);

            // Properties
            this.Property(t => t.idContrat)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nom)
                .HasMaxLength(45);

            this.Property(t => t.prenom)
                .HasMaxLength(45);

            this.Property(t => t.ville)
                .HasMaxLength(45);

            this.Property(t => t.Pays)
                .HasMaxLength(45);

            this.Property(t => t.matricule)
                .HasMaxLength(45);

            this.Property(t => t.Banque)
             .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("contrat", "bank");
            this.Property(t => t.idContrat).HasColumnName("idContrat");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.Banque).HasColumnName("Banque");
            this.Property(t => t.prenom).HasColumnName("prenom");
            this.Property(t => t.N_GSM).HasColumnName("N_GSM");
            this.Property(t => t.telephone).HasColumnName("telephone");
            this.Property(t => t.codePostal).HasColumnName("codePostal");
            this.Property(t => t.ville).HasColumnName("ville");
            this.Property(t => t.Pays).HasColumnName("Pays");
            this.Property(t => t.matricule).HasColumnName("matricule");
        }
    }
}
