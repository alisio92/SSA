using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using test.DataAccess;
using test.Hubs;
using test.Models;
using test.PresentationModels;

namespace test.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        [HttpGet]
        public ActionResult Upload()
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            var context = new ApplicationDbContext();
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var item in context.Users)
            {
                if (item.Email != User.Identity.Name) users.Add(item);
            }
            ViewBag.Users = users;
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            /*if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            var context = new ApplicationDbContext();
            ApplicationUser user = new ApplicationUser();
            foreach (var item in context.Users)
            {
                if (item.Email == User.Identity.Name) user = item;
            }
            List<FileRegistration> files = DAFileRegistration.GetFileRegistration();
            List<FileRegistration> userFiles = new List<FileRegistration>();
            List<FileRegistration> userAllowedFiles = new List<FileRegistration>();
            List<int> allowedFiles = DAFileRegistration.GetUserAllowedFiles(user.Name);
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
            ViewBag.AllowedFiles = userAllowedFiles;*/

            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            List<FileRegistration> userFiles = new List<FileRegistration>();
            userFiles = DAFileRegistration.GetFileRegistrationByName(User.Identity.Name);
            ViewBag.Files = userFiles;

            List<FileRegistration> userAllowedFiles = new List<FileRegistration>();
            userAllowedFiles = DAFileRegistration.GetUserAllowedFiles(User.Identity.Name);
            ViewBag.AllowedFiles = userAllowedFiles;

            var hub = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<Counters>();
            int numberOfLogFiles = DAFileRegistration.GetLogs().Count;
            int numberOfUploadedFiles = DAFileRegistration.GetFileRegistration().Count;
            hub.Clients.All.NumberOffFilesDownloaded(numberOfLogFiles);
            hub.Clients.All.NumberOffFilesUploaded(numberOfUploadedFiles);
            return View();
        }
        [HttpGet]
        public ActionResult Download(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);
            List<FileRegistration> userAllowedFiles = DAFileRegistration.GetUserAllowedFiles(User.Identity.Name);
            if (fileRegistration.UserName != User.Identity.Name && userAllowedFiles.Count == 0) return RedirectToAction("Dropbox", "Home");
            Boolean allowed = false;
            foreach (FileRegistration file in userAllowedFiles)
            {
                if (file.FileId == id) allowed = true;
            }
            if (!allowed && fileRegistration.UserName != User.Identity.Name) return RedirectToAction("Dropbox", "Home");
            return RedirectToAction("DownloadItem", new { id = id });
        }
        [HttpGet]
        public FileResult DownloadItem(int id)
        {
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);
            string path = Server.MapPath("/app_data/uploads/");
            path += fileRegistration.FileName;
            DAFileRegistration.SaveLog(User.Identity.Name, fileRegistration.FileName, fileRegistration.UserName);
            var hub = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<Counters>();
            int numberOfLogFiles = DAFileRegistration.GetLogs().Count;
            hub.Clients.All.NumberOffFilesDownloaded(numberOfLogFiles);
            return File(System.IO.File.ReadAllBytes(path), MediaTypeNames.Application.Octet, fileRegistration.FileName);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);
            List<FileRegistration> userAllowedFiles = DAFileRegistration.GetUserAllowedFiles(User.Identity.Name);
            if (fileRegistration.UserName != User.Identity.Name && userAllowedFiles.Count == 0) return RedirectToAction("Dropbox", "Home");
            Boolean allowed = false;
            foreach (FileRegistration file in userAllowedFiles)
            {
                if (file.FileId == id) allowed = true;
            }
            if (!allowed && fileRegistration.UserName != User.Identity.Name) return RedirectToAction("Dropbox", "Home");
            return View(fileRegistration);
        }
        [HttpPost]
        public ActionResult DeleteItem(int FileId)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            DAFileRegistration.DeleteItem(FileId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            FileRegistration fileRegistration = DAFileRegistration.GetFileRegistrationById(id);
            return View(fileRegistration);
        }

        [HttpPost]
        public ActionResult EditItem(int FileId, string description)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            DAFileRegistration.EditFileRegistrationById(FileId, description);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string description, string[] wie)
        {
            if (User.Identity.Name == "") return RedirectToAction("Dropbox", "Home");
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/app_data/uploads"), fileName);
                file.SaveAs(path);
                int id = DAFileRegistration.SaveFileRegistration(fileName, description, User.Identity.Name);

                if (wie != null)
                {
                    foreach (string user in wie)
                    {
                        DAFileRegistration.SaveDownloaders(user, id);
                    }
                }
            }
            return RedirectToAction("Upload");
        }
    }
}