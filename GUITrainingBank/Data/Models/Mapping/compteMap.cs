using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class compteMap : EntityTypeConfiguration<compte>
    {
        public compteMap()
        {
            // Primary Key
            this.HasKey(t => t.idCompte);

            // Properties
            this.Property(t => t.idCompte)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.etat)
                .HasMaxLength(255);

            this.Property(t => t.succursale)
                .HasMaxLength(255);

            this.Property(t => t.ville)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("compte", "banquematache");
            this.Property(t => t.idCompte).HasColumnName("idCompte");
            this.Property(t => t.RIB).HasColumnName("RIB");
            this.Property(t => t.codePostale).HasColumnName("codePostale");
            this.Property(t => t.dateCreation).HasColumnName("dateCreation");
            this.Property(t => t.etat).HasColumnName("etat");
            this.Property(t => t.fraisMensuel).HasColumnName("fraisMensuel");
            this.Property(t => t.numSuccursale).HasColumnName("numSuccursale");
            this.Property(t => t.solde).HasColumnName("solde");
            this.Property(t => t.succursale).HasColumnName("succursale");
            this.Property(t => t.ville).HasColumnName("ville");
        }
    }
}
