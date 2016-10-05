using Data.Models;

using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class MaterielController : Controller
    {

        IMaterielService service = null;
        public MaterielController(IMaterielService service)
        {
            this.service = service;
        }
       
        // GET: Materiel
        public ActionResult Index()
        {
            var l = service.GetAllMateriels();
            return View(l);
        }

        // GET: Materiel/Details/5
        public ActionResult Details(long id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            materiel util = service.GetById(id);
            if (util == null)
            {
                return HttpNotFound();
            }
            return View(util);
        }

        // GET: Materiel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materiel/Create
        [HttpPost]
        public ActionResult Create(materiel m)
        {
            if (ModelState.IsValid)
            {
                service.AddMateriel(m);
                service.SaveChange();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: Materiel/Edit/5
        public ActionResult Edit(int id)
        {
            materiel mat = service.GetById(id);
            return View(mat);
        }

        // POST: Materiel/Edit/5
        [HttpPost]
        public ActionResult Edit( materiel mat)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    service.editMateriel(mat);
                    service.SaveChange();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
              
            }
        }

        // GET: Materiel/Delete/5
        public ActionResult Delete(int id)
        {
            materiel mat = service.GetById(id);
            service.DeleteMateriel(mat);
            service.SaveChange();
            return RedirectToAction("Index");
        }

        // POST: Materiel/Delete/5
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
