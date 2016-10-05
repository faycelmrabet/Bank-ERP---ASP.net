using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Models
{
    public partial class banquematacheContext : DbContext
    { 
        static banquematacheContext()
        {
            Database.SetInitializer<banquematacheContext>(null);
        }

        public banquematacheContext()
            : base("Name=banquematacheContext")
        {
        }

        public DbSet<compte> comptes { get; set; }
        public DbSet<training> trainings { get; set; }
        public DbSet<trainingsession> trainingsessions { get; set; }
        public DbSet<utilisateur> utilisateurs { get; set; }
        public DbSet<materiel> materiels { get; set; }
        public DbSet<contrat> contrats { get; set; }
        public DbSet<offre> offres { get; set; }
        public DbSet<candidature> candidatures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new compteMap());
            modelBuilder.Configurations.Add(new trainingMap());
            modelBuilder.Configurations.Add(new trainingsessionMap());
            modelBuilder.Configurations.Add(new utilisateurMap());
            modelBuilder.Configurations.Add(new materielMap());
            modelBuilder.Configurations.Add(new contratMap());
            modelBuilder.Configurations.Add(new offreMap());
            modelBuilder.Configurations.Add(new candidatureMap());
        }
    }
}
