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

        public ActionResult Index(string Username)
        {
            if (TempData["Username"] == null) { return RedirectToAction("Index", "Home"); }
            User user = db.Users.FirstOrDefault(x => x.Username == Username);
            TempData["Username"] = user.Username;
            user.Status = "Online!";
            db.SaveChanges();
            return View(user);
        }
    }
}