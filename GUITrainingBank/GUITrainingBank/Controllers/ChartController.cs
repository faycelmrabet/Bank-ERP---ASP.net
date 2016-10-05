using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        IMaterielService service = new MaterielService();


        public ChartController(IMaterielService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            Dictionary<string, double> dictMateriels = new Dictionary<string, double>()
            {
                { "materiels",0}
            };
            ViewBag.PercentageMateriels = dictMateriels;

            IEnumerable<materiel> totalMateriels = service.GetAllMateriels();

            //ViewBag.totalMateriels = totalMateriels;


            if (totalMateriels.Count() != 0)
            {
                //ViewBag.idM = totalMateriels;
                ViewBag.PercentageMateriels = getDescriptionMateriels(totalMateriels);
                //Debug.WriteLine("aaaa "+ViewBag.PercentageMateriels["materiels"]);
            }

            return View();
        }


        private Dictionary<string, double> getDescriptionMateriels(IEnumerable<materiel> materiels)
        {
            int sizeMateriels = materiels.Count();
            IEnumerable<materiel> PC = materiels.Where(t => t.description.ToUpper().Contains("PC"));
            IEnumerable<materiel> Imprimante = materiels.Where(t => t.description.ToUpper().Contains("IMPRIMANTE"));
            IEnumerable<materiel> FAX = materiels.Where(t => t.description.ToUpper().Contains("FAX"));
            IEnumerable<materiel> Chaise = materiels.Where(t => t.description.ToUpper().Contains("CHAISE"));

            double tauxPC = Math.Round((double)(PC.Count() * 100 / sizeMateriels));
            double tauxImprimante = Math.Round((double)(Imprimante.Count() * 100 / sizeMateriels));
            double tauxFAX = Math.Round((double)(FAX.Count() * 100 / sizeMateriels));
            
            return new Dictionary<string, double>
            {
                {"materiels",sizeMateriels },
                {"pc",tauxPC },
                {"imprimante",tauxImprimante },
                {"fax",tauxFAX }
               
            };


        }
    }
}