using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Models;

namespace GUI.Controllers
{
    public class OffreController : Controller
    {

        IOffreService service = null;
        public OffreController(IOffreService service)
        {
            this.service = service;
        }



        // GET: Offre
        public ActionResult Index()
        {
            var O = service.GetAllOffres();
            return View(O);
        }

        // GET: Offre/Details/5
        public ActionResult Details(int id)
        {
            offre Of = service.GetById(id);
            return View(Of);
        }

        // GET: Offre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offre/Create
        [HttpPost]
        public ActionResult Create(offre of )
        {
            if (ModelState.IsValid)
            {
                service.AddOffre(of);
                service.SaveChange();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: Offre/Edit/5
        public ActionResult Edit(int id)
        {
            offre O = service.GetById(id);
            
            return View(O);
        }

        // POST: Offre/Edit/5
        [HttpPost]
        public ActionResult Edit(offre Of)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    service.editOffre(Of);
                    service.SaveChange();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }

        // GET: Offre/Delete/5
        public ActionResult Delete(int id)
        {
            offre O = service.GetById(id);
            service.DeleteOffre(O);
            service.SaveChange();
            return RedirectToAction("Index");
        }

        // POST: Offre/Delete/5
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
    }
}
