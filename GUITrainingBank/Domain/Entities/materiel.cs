using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class materiel
    {
        public int idM { get; set; }
        public string description { get; set; }
        public int id_F { get; set; }
        public string path { get; set; }
        public float price { get; set; }
        public int qte { get; set; }
        public string type { get; set; }
        public Nullable<int> admin_idUser { get; set; }
        public virtual utilisateur utilisateur { get; set; }
    }
}
