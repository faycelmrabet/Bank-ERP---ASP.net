using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class offre
    {
       
           public int idoffre { get; set; }
        [Display(Name = "Offer Name")]
        public string nomOf { get; set; }
        [Display(Name = "Offer Description")]
        public string descOf { get; set; }
    }
}
