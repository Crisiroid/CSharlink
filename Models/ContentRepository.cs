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

        public static List<Post> ShowAllPosts()
        {
            return UserRepository.db.Posts.ToList();
        }

        public static PostWithComments ShowOnePost(int id)
        {
            Post post = UserRepository.db.Posts.FirstOrDefault(x => x.Id == id);
            List <Comment> comments = UserRepository.db.Comments.Where(p => p.PostID == id).ToList();
            post.Views += 1;
            UserRepository.db.SaveChanges();
            return new PostWithComments { 
                post = post,
                comments = comments
            };
        }
        public static bool AddPost(Post post, int id, string name)
        {
            post.CreatorName = name;
            post.Views = 0;
            post.CreatorID = id;
            post.CreationDate = DateTime.Now;
            UserRepository.db.Posts.Add(post);
            UserRepository.db.SaveChanges();
            return true;
        }
    }
}