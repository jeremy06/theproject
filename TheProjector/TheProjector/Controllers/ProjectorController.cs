using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheProjector.Models;
using TheProjector.Service;

namespace TheProjector.Controllers
{

   
    public class ProjectorController : Controller
    {
        //
        // GET: /Projector/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            var person= new PersonModel();
            //todo

            return View("SignIn", person);
        }

        [ValidateAntiForgeryToken]
        public ActionResult ValidateUsers(PersonModel person)
        {
            var personSvc = new PersonService();
            Object data = personSvc.AuthenticateUserResponse(person);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult CreateUsers(PersonModel person)
        {
            var personSvc = new PersonService();
            Object data = personSvc.CreateUserResponse(person);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOff()
        {
            FormsAuthentication.SignOut();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            HttpCookie formCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            formCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(formCookie);

            HttpCookie aspnetCookie = new HttpCookie("ASP.NET_SessionId", "");
            aspnetCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(aspnetCookie);
          
            return RedirectToAction("SignIn", "Projector");
        }

        [Authorize]
        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateProject(ProjectModel project)
        {
            var projectSvc = new ProjectorService();
            Object data = projectSvc.CreateProjectResponse(project);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Person()
        {
            return View();
        }


    }
}
