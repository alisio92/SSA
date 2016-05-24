using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private List<Tablet> Tablets = new List<Tablet>();
        private const string STEP_Key = "Stap";
        private const string UserInfo_Key = "stap1";

        public OrderController()
        {
            Tablets.Add(new Tablet() { ID = 1, Name = "iPad Mini" });
            Tablets.Add(new Tablet() { ID = 2, Name = "iPad Air" });
            Tablets.Add(new Tablet() { ID = 3, Name = "Nexus 7" });
            Tablets.Add(new Tablet() { ID = 4, Name = "Surface 2" });
        }

        public ActionResult New()
        {
            if (Request.Cookies[STEP_Key] != null)
            {
                int step = int.Parse(Request.Cookies[STEP_Key].Value);
                return RedirectToAction("Next", new { step = step });
            }
            return View();
        }

        public ActionResult Next(int? step)
        {
            if (step == null) return RedirectToAction("New");

            HttpCookie stepCookie = new HttpCookie(STEP_Key);
            stepCookie.Value = step.Value.ToString();
            stepCookie.Expires = DateTime.Now.AddDays(1);
            Response.SetCookie(stepCookie);

            switch (step.Value)
            {
                case 1:
                    return View("Step1");
                case 2:
                    /*ViewBag.Company = Request.Form["company"].ToString();
                    ViewBag.FirstName = Request.Form["firstname"].ToString();
                    ViewBag.LastName = Request.Form["lastname"].ToString();*/

                    HttpCookie step1Cookie = new HttpCookie(UserInfo_Key);

                    string company = Request.Form["company"].ToString();
                    string firstName = Request.Form["firstname"].ToString();
                    string lastName = Request.Form["lastname"].ToString();
                    string cookieValue = string.Format("{0}-{1}-{2}", company, firstName, lastName);

                    /*step1Cookie["Company"] = @ViewBag.Company;
                    step1Cookie["Name"] = @ViewBag.LastName;
                    step1Cookie["FirstName"] = @ViewBag.FirstName;*/
                    step1Cookie.Value = cookieValue;
                    step1Cookie.Expires = DateTime.Now.AddDays(1);
                    Response.SetCookie(step1Cookie);

                    if (Request.Cookies[UserInfo_Key] != null)
                    {
                        ViewBag.Company = Request.Cookies[STEP_Key]["Company"];
                        ViewBag.FirstName = Request.Cookies[STEP_Key]["Name"];
                        ViewBag.LastName = Request.Cookies[STEP_Key]["FirstName"];
                    }

                    ViewBag.Tablets = Tablets;

                    return View("Step2");
                case 3:
                    string waarde = Request.Cookies[UserInfo_Key].Value;
                    ViewBag.Company = waarde.Split('-')[0];
                    ViewBag.FirstName = waarde.Split('-')[1];
                    ViewBag.LastName = waarde.Split('-')[2];

                    if (Request.Cookies[UserInfo_Key] == null)
                    {
                        string cookieValuestep2 = string.Format("{0}-{1}-{2}", Request.Form["tablet"], Request.Form["case"], Request.Form["assurance"]);
                    }
                    /*ViewBag.Company = Request.Form["company"].ToString();
                    ViewBag.FirstName = Request.Form["firstname"].ToString();
                    ViewBag.LastName = Request.Form["lastname"].ToString();*/
                    /*HttpCookie _userInfo = Request.Cookies["UserInfo"];
                    if (_userInfo != null)
                    {
                        ViewBag.Company = _userInfo["UserCompany"];
                        ViewBag.FirstName = _userInfo["UserFirstName"];
                        ViewBag.LastName = _userInfo["UserLastName"];
                    }*/

                    int tabletId = int.Parse(Request.Form["tablet"].ToString());
                    ViewBag.Tablet = Tablets.Find(t => t.ID == tabletId).Name;
                    if (!String.IsNullOrEmpty(Request.Form["case"]))
                        ViewBag.Case = true;
                    else
                        ViewBag.Case = false;

                    if (!String.IsNullOrEmpty(Request.Form["assurance"]))
                        ViewBag.Assurance = true;
                    else
                        ViewBag.Assurance = false;

                    /*HttpCookie _userInfoSet2 = new HttpCookie("UserInfo");
                    _userInfoSet2["UserCompany"] = @ViewBag.Company;
                    _userInfoSet2["UserLastName"] = @ViewBag.LastName;
                    _userInfoSet2["UserFirstName"] = @ViewBag.FirstName;
                    _userInfoSet2["UserTablet"] = @ViewBag.Tablet;
                    if (@ViewBag.Case) _userInfoSet2["UserCase"] = "true";
                    else _userInfoSet2["UserCase"] = "fale";
                    if (@ViewBag.Assurance) _userInfoSet2["UserAssurance"] = "true";
                    else _userInfoSet2["UserAssurance"] = "false";*/
                    return View("Step3");
                case 4:
                    /*HttpCookie _userInfoDelete = Request.Cookies["UserInfo"];
                    _userInfoDelete.Expires = DateTime.Now.AddDays(-1d);*/
                    return View("Step4");
                default:
                    return RedirectToAction("New");
            }
        }
    }
}