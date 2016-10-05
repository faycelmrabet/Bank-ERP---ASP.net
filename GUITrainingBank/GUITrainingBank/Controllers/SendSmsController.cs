using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUITrainingBank.Controllers
{
    public class SendSmsController : Controller
    {
        // GET: SendSms
        public ActionResult Index()
        {
            return View();
        }

        // GET: SendSms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SendSms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendSms/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SendSms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SendSms/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SendSms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SendSms/Delete/5
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
        public ActionResult sms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sms(string message , string number)
        {
            if(message.Length != 0)
            {
                sendSMS ss = new sendSMS();
                ss.send(message, number);
            }
            return View();

        }
    }

        class sendSMS
        {
            public string send(string s,string num)
            {
                String message = HttpUtility.UrlEncode(s);
                using (var wb = new WebClient())
                {
                    byte[] response = wb.UploadValues("http://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"username" , "freedo1@live.fr"},
                {"hash" , ""},
                {"numbers" , num},
                {"message" , message},
                {"sender" , "Semer"}
                });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    return result;
                }
            }
        }
    
}
