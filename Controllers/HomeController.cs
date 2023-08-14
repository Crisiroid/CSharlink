using Csharlink.Data;
using Csharlink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Csharlink.Controllers
{
    public class HomeController : Controller
    {
        public CsharlinkDB db = new CsharlinkDB();
        public ActionResult Index()
        {
            if (TempData["LoginFailed"].Equals("true"))
            {
                ViewBag.pm = "We don't have you on record. please register";
            }
            return View();
        }

        public ActionResult About()
        {

            return View();

        }
        public ActionResult Login(string Username, string Password)
        {
            if (CheckUsername(Username, Password))
            {
                User user = db.Users.Find(Username);
                TempData["Username"] = user.Username;
                Session["UserStatus"] = "Login";
                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                TempData["LoginFailed"] = "true";
                return RedirectToAction("Index", "Home");
            }
        }


        public bool CheckUsername(string Username, string Password)
        {
            return db.Users.Any(u => u.Username == Username && u.Password == Password);
        }


    }
}