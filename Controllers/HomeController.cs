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
        public ActionResult Login(string Username, string Password)
        {
            if (CheckUsername(Username, HashUtility.HashPassword(Password)))
            {
                User user = db.Users.FirstOrDefault(x => x.Username == Username);
                TempData["Username"] = user.Username;
                user.Status = "Online!";
                db.SaveChanges();
                Session["UserStatus"] = "Login";
                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                TempData["LoginStatus"] = "Login Failed. Sign up!";
                return RedirectToAction("Index", "Home");
            }
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

        public bool CheckUsername(string Username, string Password)
        {
            return db.Users.Any(u => u.Username == Username && u.Password == Password);
        }


    }
}