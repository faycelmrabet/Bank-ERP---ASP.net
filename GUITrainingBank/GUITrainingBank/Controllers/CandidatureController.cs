using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Data.Models;
using System.IO;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using System.Text;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace GUI.Controllers
{
    public class CandidatureController : Controller
    {
        ICandidatureService s;

        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "PiDrive";
        FilesResource.InsertMediaUpload request;
        public CandidatureController()
        {
                
        }
        public CandidatureController(ICandidatureService s)
        {
            this.s = s;

        }
        public static Boolean downloadFile(DriveService _service, Google.Apis.Drive.v2.Data.File _fileResource, string _saveTo)
        {

            if (!String.IsNullOrEmpty(_fileResource.DownloadUrl))
            {
                try
                {
                    var x = _service.HttpClient.GetByteArrayAsync(_fileResource.DownloadUrl);
                    byte[] arrBytes = x.Result;
                    System.IO.File.WriteAllBytes(_saveTo, arrBytes);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    return false;
                }
            }
            else
            {
                // The file doesn't have any content stored on Drive.
                return false;
            }
        }


        // GET: Candidature
        public ActionResult Index()
        {
             var candidatures = s.getAllCandidatures();
             List<CandidatureViewModel> cvm = new List<CandidatureViewModel>();
             foreach (var item in candidatures)
             {
                 cvm.Add(new CandidatureViewModel
                 {
                     Id=item.id,
                     CandidateName = item.CandidateName,
                     Cv = item.Cv,
                     //urlCv=item.urlCv,
                     //dateCreation=(DateTime)item.dateCreation
                 });
             }
             return View(cvm);
          
        }

        // GET: Candidature/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidature/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Download(int id)
        {
            //***********************Auth**************//
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret_871887422935-6o2u9sh6562ddakm77t7vcbkecrarhf2.apps.googleusercontent.com (1).json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/PiDrive");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.

            FilesResource.ListRequest listRequest = service.Files.List();


            
            // List files.
            IList<Google.Apis.Drive.v2.Data.File> files = listRequest.Execute().Items;
            var c = s.getCandidature(id);
            if (files != null && files.Count > 0)
            {
                foreach (var f in files)
                {
                    if (f.Id.Equals(c.ifFile))
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Download/"),f.Title );
                        using (FileStream w = System.IO.File.Create(path)) {
                      bool p = downloadFile(service, f, path);
                        }
                         }
                }
            }
            return View();
        }



        // POST: Candidature/Create
        [HttpPost]
        public ActionResult Create(CandidatureViewModel cvm, HttpPostedFileBase cv)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    RedirectToAction("Create");

                }
                //***********************Upload**************//
                UserCredential credential;

                using (var stream =
                    new FileStream("client_secret_871887422935-6o2u9sh6562ddakm77t7vcbkecrarhf2.apps.googleusercontent.com (1).json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/PiDrive");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // Define parameters of request.
                FilesResource.ListRequest listRequest = service.Files.List();
                
                // List files.
                IList<Google.Apis.Drive.v2.Data.File> files = listRequest.Execute().Items;

                //**************

                Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
                body.Title = cv.FileName;
                body.Description = "A test document";
                body.MimeType = "application/pdf";

                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), cv.FileName);
               cv.SaveAs(path);
                byte[] byteArray = System.IO.File.ReadAllBytes(path);
                MemoryStream stream2;

                stream2 = new System.IO.MemoryStream(byteArray);
                

                    request = service.Files.Insert(body, stream2, "application/pdf");

                    request.Upload();


                    Google.Apis.Drive.v2.Data.File file = request.Body;
               
                // TODO: Add insert logic here
                candidature obj = new candidature
                {
                    CandidateName = cvm.CandidateName,
                    
                    urlCv = request.ResponseBody.DownloadUrl,
                    dateCreation = (DateTime)request.ResponseBody.CreatedDate,
               ifFile=request.ResponseBody.Id
                };


                s.AddCandidature(obj);

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return View();            }
        }
// GET: Candidature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidature/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, candidature c)
        {
            try
            {
                // TODO: Add delete logic here
                
                s.DeleteCandidature(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
