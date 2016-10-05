using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Data.Models
{
    public partial class utilisateur
    { 
        public utilisateur()
        {
            this.trainings = new List<training>();
        }

        public string DTYPE { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }
        public string Adress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        [Display(Name = "Phone")]
        public string tel { get; set; }
        public Nullable<int> cin { get; set; }
        public Nullable<System.DateTime> dateDelivrance { get; set; }
        public Nullable<System.DateTime> dateNaissance { get; set; }
        public string etatCivil { get; set; }
        public string lieuDelivrance { get; set; }
        public string lieuNassance { get; set; }
        public string login { get; set; }
        public string nationnalite { get; set; }
        public string password { get; set; }
        public string profession { get; set; }
        public string competence { get; set; }
        public string paysOrigine { get; set; }
        public Nullable<float> salaireParSession { get; set; }


        //manel
        [Display(Name = "Grade")]
        public string grade { get; set; }
        [Display(Name = "Salary")]
        public Nullable<double> salaire { get; set; }
        [Display(Name = "Prime Admin")]
        public Nullable<double> primAdmin { get; set; }
        [Display(Name = "Prime Officer")]
        public Nullable<double> primOfficer { get; set; }
        [Display(Name = "Duration")]
        public Nullable<double> dureeDheursTrll { get; set; }
        [Display(Name = "Salary")]
        public Nullable<double> salaireEmp { get; set; }
        [Display(Name = "Company Address")]
        public string adresseSociete { get; set; }
        [Display(Name = "Offer Name")]
        public string nomSociete { get; set; }
        [Display(Name = "Compaby Name")]
        public string numSociete { get; set; }
        //fin manel
        public virtual ICollection<training> trainings { get; set; }

        public virtual ICollection<materiel> materiels { get; set; }
    }
}
