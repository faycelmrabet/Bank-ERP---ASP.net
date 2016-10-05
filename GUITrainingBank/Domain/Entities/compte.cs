using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class compte
    {
        public int idCompte { get; set; }
        public int RIB { get; set; }
        public int codePostale { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }
        public string etat { get; set; }
        public double fraisMensuel { get; set; }
        public int numSuccursale { get; set; }
        public int solde { get; set; }
        public string succursale { get; set; }
        public string ville { get; set; }
    }
}
