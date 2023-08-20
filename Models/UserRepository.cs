using Csharlink.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Csharlink.Models
{
    public class UserRepository
    {
        public static CsharlinkDB db = new CsharlinkDB();

        public static object TempData { get; private set; }

        public static void Signup(User user)
        {
            user.Password = HashUtility.HashPassword(user.Password);
            user.PostNum = 0;
            user.Status = "Offline";
            user.AccessType = "User";
            user.Likes = 0;
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static User Login(string Username, string Password)
        {
            if (CheckUsername(Username, HashUtility.HashPassword(Password)))
            {
                User user = db.Users.FirstOrDefault(x => x.Username == Username);
                user.Status = "Online!";
                db.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }

        public static bool Logout(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            user.Status = "Offile!";
            db.SaveChanges();
            return true;

        }

        public static bool UsernameAvailability(string Username)
        {
            return db.Users.Any(u => u.Username == Username);
        }

        public static User findUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }


        public static bool CheckUsername(string Username, string Password)
        {
            return db.Users.Any(u => u.Username == Username && u.Password == Password);
        }
    }
}