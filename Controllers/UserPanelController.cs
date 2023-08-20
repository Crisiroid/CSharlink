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
        public ActionResult Login(string Username, string Password)
        {
            User user = UserRepository.Login(Username, Password);
            if (user != null)
            {
                if (TempData["PostAddStatus"] != null)
                {
                    ViewBag.pm = TempData["PostAddStatus"].ToString();
                }
                TempData["Username"] = Username;
                Session["UserStatus"] = "Login";
                return RedirectToAction("Index", "UserPanel", new { u = (int) user.Id});
            }
            else
            {
                TempData["LoginStatus"] = "Login Failed. Sign up!";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Index(int u)
        {
            return View(UserRepository.findUser(u));            
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
        [HttpGet]
        public ActionResult CreatePost(int id)
        {
            TempData["id"] = id;
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
            if(ContentRepository.AddPost(post, (int)TempData["id"], TempData["Username"].ToString()))
            {
                TempData["PostAddStatus"] = "Post Added Successfully";
            }
            else
            {
                TempData["PostAddStatus"] = "We Couldn't add You post";
            }
            return RedirectToAction("Index", "UserPanel", new {u = (int)TempData["id"] });

        }

    }
}