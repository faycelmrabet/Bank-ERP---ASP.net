using Data.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class EmployeeController : Controller
    {
                IUtilisateurService ause;
        public EmployeeController(IUtilisateurService ause)
        {
            this.ause = ause;
                
        }
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            List<utilisateur> utilisateurs = ause.getAllEmployees();
            List<utilisateur> employee = new List<utilisateur>();
            foreach (utilisateur u in utilisateurs)
            {
                if (u.DTYPE == "isemployee")
                {
                    employee.Add(u);
                }
            }

            return View(employee);
        }

        //
        // GET: /Employee/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur util = ause.GetEmployee(id);
            if (util == null)
            {
                return HttpNotFound();
            }
            return View(util);

            //ViewData["DetailInfo"] = id;
            //foreach (utilisateur u in ause.getAllEmployees())
            //{
            //    if ((u.DTYPE == "isemployee") && (u.idUser == id))
            //    {
            //        return View(u);
            //    }
            //}
            //return Index();
        }

        //
        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create
        [HttpPost]
        public ActionResult Create(utilisateur a)
        {

            if (ModelState.IsValid)
            {
                a.DTYPE = "isemployee";


                ause.AddEmployee(a);
                return RedirectToAction("Index");
            }


            return View();
        }

        //
        // GET: /Employee/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            utilisateur util = ause.GetEmployee(id);
            if (util == null)
            {
                return HttpNotFound();
            }
            return View(util);

            //utilisateur u = new utilisateur();
            // foreach (utilisateur i in ause.getAllEmployees())
            // {
            //     if (i.idUser == id)
            //     {
            //         u = i;

            //     }

            // }
            // ause.DeleteEmployeeById(id);

            // return View(u);
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, utilisateur u)
        {
            utilisateur ut = ause.GetEmployee(id);

            ut.Adress = u.Adress;
            ut.firstName = u.firstName;
            ut.lastName = u.lastName;
            ut.tel = u.tel;
            ut.mail = u.mail;
            ut.cin = u.cin;
            ut.dureeDheursTrll = u.dureeDheursTrll;
            ut.salaireEmp = u.salaireEmp;


            ause.UpdateEmployee(ut);
            return RedirectToAction("Index");
        }

        //
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id)
        {

            utilisateur u = new utilisateur();
            foreach (utilisateur i in ause.getAllEmployees())
            {
                if (i.idUser == id)
                {
                    u = i;
                }
            }
           // ause.DeleteEmployeeById(id);


            return View(u);
        }

        //
        // POST: /Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, utilisateur u)
        {
          ause.DeleteEmployeeById(id);
            List<utilisateur> users = ause.getAllEmployees();
            List<utilisateur> employee = new List<utilisateur>();
            foreach (utilisateur i in users)
            {
                if (u.DTYPE == "isemployee")
                {
                    employee.Add(i);
                }
            }
            return RedirectToAction("Index", employee);
            }
        }
    }

