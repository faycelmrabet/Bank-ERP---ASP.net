using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class contrat
    {
        public int idContrat { get; set; }
        public string nom { get; set; }
        public string Banque { get; set; }
        public string prenom { get; set; }
        public Nullable<int> N_GSM { get; set; }
        public Nullable<int> telephone { get; set; }
        public Nullable<int> codePostal { get; set; }
        public string ville { get; set; }
        public string Pays { get; set; }
        public string matricule { get; set; }
    }
}
