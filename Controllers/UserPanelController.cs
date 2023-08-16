using Csharlink.Data;
using Csharlink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Csharlink.Controllers
{
    public class UserPanelController : Controller
    {
        public static CsharlinkDB db = new CsharlinkDB();

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            if (CheckUsername(Username, HashUtility.HashPassword(Password)))
            {
                User user = db.Users.FirstOrDefault(x => x.Username == Username);
                TempData["Username"] = user.Username;
                user.Status = "Online!";
                Session["UserStatus"] = "Login";
                db.SaveChanges();
                return View(user);
            }
            else
            {
                TempData["LoginStatus"] = "Login Failed. Sign up!";
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Logout(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            TempData["Username"] = null;
            user.Status = "Offile!";
            db.SaveChanges();
            Session["UserStatus"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ContentList(int id)
        {
            return View(db.Posts.Where(x => x.CreatorID == id).ToList());
        }
        public bool CheckUsername(string Username, string Password)
        {
            return db.Users.Any(u => u.Username == Username && u.Password == Password);
        }
    }
}