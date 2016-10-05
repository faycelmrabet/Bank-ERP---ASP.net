using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class utilisateurMap : EntityTypeConfiguration<utilisateur>
    {
        public utilisateurMap()
        {
            // Primary Key
            this.HasKey(t => t.idUser);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.idUser)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Adress)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.mail)
                .HasMaxLength(255);

            this.Property(t => t.tel)
                .HasMaxLength(255);

            this.Property(t => t.etatCivil)
                .HasMaxLength(255);

            this.Property(t => t.lieuDelivrance)
                .HasMaxLength(255);

            this.Property(t => t.lieuNassance)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.nationnalite)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.profession)
                .HasMaxLength(255);

            this.Property(t => t.competence)
                .HasMaxLength(255);

            this.Property(t => t.paysOrigine)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("utilisateur", "banquematache");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.Adress).HasColumnName("Adress");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.mail).HasColumnName("mail");
            this.Property(t => t.tel).HasColumnName("tel");
            this.Property(t => t.cin).HasColumnName("cin");
            this.Property(t => t.dateDelivrance).HasColumnName("dateDelivrance");
            this.Property(t => t.dateNaissance).HasColumnName("dateNaissance");
            this.Property(t => t.etatCivil).HasColumnName("etatCivil");
            this.Property(t => t.lieuDelivrance).HasColumnName("lieuDelivrance");
            this.Property(t => t.lieuNassance).HasColumnName("lieuNassance");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.nationnalite).HasColumnName("nationnalite");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.profession).HasColumnName("profession");
            this.Property(t => t.competence).HasColumnName("competence");
            this.Property(t => t.paysOrigine).HasColumnName("paysOrigine");
            this.Property(t => t.salaireParSession).HasColumnName("salaireParSession");
        }
    }
}
