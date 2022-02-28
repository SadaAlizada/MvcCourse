using mvc_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_course.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

       [HttpGet]
       public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Singin()
        {
            return View();
        }

        DBGR76Entities db = new DBGR76Entities();
        
        [HttpPost]

        public ActionResult Register(REGISTRATION user)
        {
            try
            {
                db.REGISTRATION.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");



            }
            catch (Exception)
            {

                return View();

            }

        }

        [HttpPost]

        public ActionResult Singin(REGISTRATION userr)
        {
            bool result = IsValid(userr.EMAIL, userr.PASSWORD);

            if (result)

            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.massage = "Login Falled";

            }

            return View(userr);

        }

        public bool IsValid(string email, string password)
        {
            bool IsValid = false;

            var user = db.REGISTRATION.FirstOrDefault(u => u.EMAIL == email);

            if (User!=null)
            {
                if (user.PASSWORD==password)
                {
                    IsValid = true;

                }

            }
            return IsValid;
        }
    }
}