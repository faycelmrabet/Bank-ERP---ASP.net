using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUITrainingBank.Controllers
{
    public class TrainingController : Controller
    {
       

        ITrainingService trs;

        public TrainingController(ITrainingService trs)
        {
            this.trs = trs;      
        }
        // GET: Training
        public ActionResult Index()
        {
            var l = trs.getAllTraining();
            return View(l);
        }

        // GET: Training/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training train = trs.getOneTraining(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Training/Create
        [HttpPost]
        public ActionResult Create(training t)
        {
            if (ModelState.IsValid)
            {
                trs.addTraining(t);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            training train = trs.getOneTraining(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // POST: Training/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, training train)
        {
            training tr = trs.getOneTraining(id);

            tr.lieu = train.lieu;
            tr.dateDebut = train.dateDebut;
            tr.dateFin = train.dateFin;
            tr.nombreInscrit = train.nombreInscrit;
            tr.theme = train.theme;
            trs.UpdateTraining(tr);
            return RedirectToAction("Index");
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            training tr = trs.getOneTraining(id);
            trs.DeleteTraining(id);
            return RedirectToAction("Index");
        }

        // POST: Training/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            training tr = trs.getOneTraining(id);
            trs.DeleteTraining(id);
            return RedirectToAction("Index");
        }
    }
}
