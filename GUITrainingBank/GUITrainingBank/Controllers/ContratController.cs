using Data.Models;
using Rotativa.MVC;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class ContratController : Controller
    {
        IContratService ause;
        public ContratController(IContratService ause)
        {
            this.ause = ause;
        }
        // GET: Contrat
        public ActionResult Index()
        {

            var l = ause.getAllContrats();
            return View(l);
        }

        // GET: Contrat/Details/5
        public ActionResult Details(int id)
        {
            var ctr = ause.getById(id);
            return View(ctr);
        }

        // GET: Contrat/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Contrat/Create
        [HttpPost]
        public ActionResult Create (contrat c)
        {
            
                if(ModelState.IsValid)
                {
                    ause.AddContrat(c);
                    return RedirectToAction("Index");
                }
            
            
            else
            {
                return View();
            }
        }

        // GET: Contrat/Edit/5
        public ActionResult Edit(int id)
        {
            contrat c = ause.getById(id);
            return View(c);
        }

        // POST: Contrat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,contrat c)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    contrat c1 = ause.getById(id);
                    c1.nom = c.nom;
                    c1.prenom = c.prenom;
                    c1.N_GSM = c.N_GSM;
                    c1.telephone = c.telephone;
                    c1.matricule = c.matricule;
                    c1.ville = c.ville;
                    c1.codePostal = c.codePostal;
                    c1.Banque = c.Banque;
                    c1.Pays = c.Pays;
                    ause.Update(c1);
                    



                }
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                
                return View();
            }
        }

        // GET: Contrat/Delete/5
        public ActionResult Delete(int id)
        {
            contrat ctr = ause.getById(id);
            ause.DeleteContact(ctr);
            return RedirectToAction("Index");
        }

        // POST: Contrat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Show(int id)
        {
            var con = ause.getById(id);
            ViewBag.someStringValue = con.Banque;
            return View();
        }

        public ActionResult ExportPDF()
        {
            return new ActionAsPdf("index")
            {
                FileName = Server.MapPath("~/Content/Invoice.pdf")
            };


        }
    }

}
