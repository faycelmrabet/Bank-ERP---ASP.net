using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUITrainingBank.Controllers
{
    public class TrainingSessionController : Controller
    {

 

        ITrainingSessionService trs;
        public TrainingSessionController(ITrainingSessionService trs)
        {
            this.trs = trs;      
        }
        // GET: TrainingSession
        public ActionResult Index()

        {
             var l = trs.getAllTrainingSession();
             return View(l);
            //return View(db.trainingsessions.ToList());
        }

        // GET: TrainingSession/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingsession train = trs.getOneTrainingSession(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // GET: TrainingSession/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingSession/Create
        [HttpPost]
        public ActionResult Create(trainingsession tra)
        {
            if (ModelState.IsValid)
            {
                trs.AddTrainingSession(tra);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
            
        }

        // GET: TrainingSession/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingsession train = trs.getOneTrainingSession(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
            
        }

        // POST: TrainingSession/Edit/5
        [HttpPost]
        
        public ActionResult Edit(int id, trainingsession train)
        {
            
                trainingsession tr = trs.getOneTrainingSession(id);
                
                tr.cout = train.cout;
                tr.dateDebut = train.dateDebut;
                tr.dateFin = train.dateFin;
                tr.description = train.description;
                tr.objective = train.objective;
                trs.UpdateTrainingSession(tr);
                return RedirectToAction("Index");
    
            
}

// GET: TrainingSession/Delete/5
public ActionResult Delete(int id)
        {

            trainingsession tr = trs.getOneTrainingSession(id);
            trs.DeleteTrainingSession(id);
            return RedirectToAction("Index");
        }

        // POST: TrainingSession/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,trainingsession tra)
        {
            return View();
        }
        
    }
}
