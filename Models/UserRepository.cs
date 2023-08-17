using Csharlink.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public static class UserRepository
    {
        public static CsharlinkDB db = new CsharlinkDB();
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
    }
}