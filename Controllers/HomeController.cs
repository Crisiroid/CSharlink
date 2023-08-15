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
        public static CsharlinkDB db = new CsharlinkDB();
        public ActionResult Index()
        {
            if (TempData["LoginStatus"]!= null)
            {
                ViewBag.pm = TempData["LoginStatus"].ToString();
            }
            return View();
        }

        public ActionResult About()
        {

            return View();

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Password = HashUtility.HashPassword(user.Password);
            user.PostNum = 0;
            user.Status = "Offline";
            user.AccessType = "User";
            user.Likes = 0;
            db.Users.Add(user); 
            db.SaveChanges();
            TempData["LoginStatus"] = "Account Created Successfully. You can login now!";
            return RedirectToAction("Index", "Home");
        }


    }
}