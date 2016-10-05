using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class trainingsession
    {
        public trainingsession()
        {
            this.trainings = new List<training>();
        }

        public int idTS { get; set; }
        public float cout { get; set; }
        public Nullable<System.DateTime> dateDebut { get; set; }
        public Nullable<System.DateTime> dateFin { get; set; }
        public string description { get; set; }
        public string objective { get; set; }
        public virtual ICollection<training> trainings { get; set; }
    }
}
