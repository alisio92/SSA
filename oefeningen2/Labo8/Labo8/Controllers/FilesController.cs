using Labo8.DataAcces;
using Labo8.Models;
using Labo8.PresentationModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Labo8.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            return View();
        }

         [HttpGet]
        public ActionResult Upload()
        {
            var context = new ApplicationDbContext();
            ViewBag.Users = context.Users;
            return View();
        }

        [HttpPost]
         public ActionResult Upload(HttpPostedFileBase file, string description, string[] wie){
             if (file != null && file.ContentLength > 0)
             {
                 var fileName = Path.GetFileName(file.FileName);
                 var path = Path.Combine(Server.MapPath("~/app_data/uploads"), fileName);
                 file.SaveAs(path);
                 int id = DAFileRegistration.SaveFileRegistration(fileName, description, User.Identity.Name);


                 foreach (string user in wie)
                     DAFileRegistration.SaveDownloaders(user, id);
             }
             return RedirectToAction("Files");
        }

                     public List<FileRegistration> userAllowedFiles = new List<FileRegistration>();

        public ActionResult Files()
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            var context = new ApplicationDbContext();
            ApplicationUser user = new ApplicationUser();
            foreach (var item in context.Users)
            {
                if (item.Email == User.Identity.Name) user = item;
            }
             List<FileRegistration> files = DAFileRegistration.GetFileRegistration();
             List<FileRegistration> userFiles = new List<FileRegistration>();
             //List<FileRegistration> userAllowedFiles = new List<FileRegistration>();
             List<int> allowedFiles = DAFileRegistration.GetUserAllowedFiles(user.Id);
            foreach (FileRegistration file in files)
            {
                if (file.UserName == user.Email) userFiles.Add(file);
                if (DAFileRegistration.getFunctionUser(user.Id)) userAllowedFiles.Add(file);
                foreach (int id in allowedFiles)
                {
                    if (id == file.FileId) userAllowedFiles.Add(file);
                }
            }
            ViewBag.Files = userFiles;
            ViewBag.AllowedFiles = userAllowedFiles;
            PMIndex newFile = new PMIndex();
            newFile.NewFile = new SelectList(DAFileRegistration.GetFileRegistration(), "FileId", "Description", "FileName", "UploadTime", "UserName");
            return View(newFile);
        }

        [HttpGet]
        public FileResult Download(int id)
        {
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);


            var context = new ApplicationDbContext();
            ApplicationUser user = new ApplicationUser();
            foreach (var item in context.Users)
            {
                if (item.Email == User.Identity.Name) user = item;
            }
            List<FileRegistration> files = DAFileRegistration.GetFileRegistration();
            List<FileRegistration> userFiles = new List<FileRegistration>();
            //List<FileRegistration> userAllowedFiles = new List<FileRegistration>();
            List<int> allowedFiles = DAFileRegistration.GetUserAllowedFiles(user.Id);
            foreach (FileRegistration file in files)
            {
                if (file.UserName == user.Email) userFiles.Add(file);
                if (DAFileRegistration.getFunctionUser(user.Id)) userAllowedFiles.Add(file);
                foreach (int id2 in allowedFiles)
                {
                    if (id2 == file.FileId) userAllowedFiles.Add(file);
                }
            }

             string path = "";

            foreach(FileRegistration file in userAllowedFiles){
            if (file.FileId == fileRegistration.FileId)
            {

                path = Server.MapPath("/app_data/uploads/");
                path += fileRegistration.FileName;
            }
            
                }
           
            return File(System.IO.File.ReadAllBytes(path), MediaTypeNames.Application.Octet, fileRegistration.FileName);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);
            return View(fileRegistration);
        }

        //Dit wordt uitgevoerd wanneer er op de deleteknop gedrukt wordt van een file
        [HttpPost]
        public ActionResult DeleteItem(int FileId)
        {
            string actie = "";
            FileRegistration GewensteFile = DAFileRegistration.GetFileRegistrationById(FileId);
            if (GewensteFile.UserName == User.Identity.Name)
            {
                DAFileRegistration.DeleteItem(FileId);
                actie = "Files";
            }
            else
            {
                actie = "Index"; 
            }

            return RedirectToAction(actie);


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);
            ViewBag.FileId = id;
            return View(fileRegistration);
        }

         [HttpPost]
        public ActionResult EditItem(int FileId, string Description)
        {
            string actie = "";
            FileRegistration GewensteFile = DAFileRegistration.GetFileRegistrationById(FileId);
            if (GewensteFile.UserName == User.Identity.Name)
            {
                DAFileRegistration.UpdateDescription(FileId,Description);
                actie = "Files";
            }
            else
            {
                actie = "Index";
            }

            return RedirectToAction(actie);


        }

    }
}