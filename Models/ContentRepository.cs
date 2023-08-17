using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public class ContentRepository
    {
        public static List<Post> ShowPosts(int id)
        {
            return UserRepository.db.Posts.Where(x => x.CreatorID == id).ToList();
        }
    }
}