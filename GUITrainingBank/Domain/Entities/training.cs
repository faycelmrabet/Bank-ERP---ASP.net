using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class training
    {
        public training()
        {
            this.utilisateurs = new List<utilisateur>();
            this.trainingsessions = new List<trainingsession>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idT { get; set; }
        public Nullable<System.DateTime> dateDebut { get; set; }
        public Nullable<System.DateTime> dateFin { get; set; }
        public string lieu { get; set; }
        public int nombreInscrit { get; set; }
        public string theme { get; set; }
        public virtual ICollection<utilisateur> utilisateurs { get; set; }
        public virtual ICollection<trainingsession> trainingsessions { get; set; }
    }
}
