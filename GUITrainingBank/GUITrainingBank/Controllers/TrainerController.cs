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
    public class TrainerController : Controller
    {
        utilisateur u;
        ITrainerService trs;
        public TrainerController(ITrainerService trs)
        {
            this.trs = trs;
        }
        // GET: Trainer
        public ActionResult Index()
        {
            List<utilisateur> utilisateurs = trs.getAllTrainer();
            List<utilisateur> trainer = new List<utilisateur>();
            foreach (utilisateur u in utilisateurs)
            {
                if (u.DTYPE == "Trainer")
                {
                    trainer.Add(u);
                }
            }

            return View(trainer);
        }

        // GET: Trainer/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur util = trs.getOneTrainer(id);
            if (util == null)
            {
                return HttpNotFound();
            }
            return View(util);
        }

        // GET: Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainer/Create
        [HttpPost]
        public ActionResult Create(utilisateur t)
        {
            if (ModelState.IsValid)
            {

                t.DTYPE = "Trainer";
                trs.addTrainer(t);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur util = trs.getOneTrainer(id);
            if (util == null)
            {
                return HttpNotFound();
            }
            return View(util);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, utilisateur util)
        {
            utilisateur ut = trs.getOneTrainer(id);

            ut.Adress = util.Adress;
            ut.firstName = util.firstName;
            ut.lastName = util.lastName;
            ut.tel = util.tel;
            ut.mail = util.mail;
            ut.competence = util.competence;
            ut.paysOrigine = util.paysOrigine;
            ut.salaireParSession = util.salaireParSession;
            trs.UpdateTrainer(ut);
            return RedirectToAction("Index");
        }

        // GET: Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            utilisateur tr = trs.getOneTrainer(id);
            trs.DeleteTrainer(id);
            return RedirectToAction("Index");
        }

        // POST: Trainer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            utilisateur tr = trs.getOneTrainer(id);
            trs.DeleteTrainer(id);
            return RedirectToAction("Index");
        }
    }
}
