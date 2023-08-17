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
        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            if(UserRepository.Login(Username, Password))
            {
                TempData["Username"] = Username;
                Session["UserStatus"] = "Login";
                return View();
            }
            else
            {
                TempData["LoginStatus"] = "Login Failed. Sign up!";
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Logout(int id)
        {
            if (UserRepository.Logout(id))
            {
                TempData["Username"] = null;
                Session["UserStatus"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "UserPanel");
            }
            
        }

        public ActionResult ContentList(int id)
        {
            return View(ContentRepository.ShowPosts(id));
        }
       
    }
}