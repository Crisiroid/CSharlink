using Csharlink.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public static bool Login(string Username, string Password)
        {
            if (CheckUsername(Username, HashUtility.HashPassword(Password)))
            {
                User user = db.Users.FirstOrDefault(x => x.Username == Username);
                user.Status = "Online!";
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckUsername(string Username, string Password)
        {
            return db.Users.Any(u => u.Username == Username && u.Password == Password);
        }
    }
}