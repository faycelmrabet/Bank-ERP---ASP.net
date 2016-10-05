/* FileName: SendMailController.cs
Project Name: MvcSendMail
Date Created: 9/15/2014PM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License: 

*/


using System.Web.Mvc;
using MvcSendMail.Models;
namespace MvcSendMail.Controllers
{
    public class SendMailController : Controller
    {
        //
        // GET: /SendMail/

        public ActionResult Index()
        {
            var model = new ContactModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "";
                string smtpPassword =   "";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 25;

                string emailTo = model.Email; 
                string subject = model.Subject;
                string body = string.Format("You've received contact from: <b>{0}</b><br/>Email: {1}<br/>content: </br>{2}",
                    model.UserName, model.Email, model.Message);

                EmailService service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Thank you for contacting us.");
                else ModelState.AddModelError("", "Send a message failed , please try again.");                 
            }
            return View(model);
        }
    }
}
