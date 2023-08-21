using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public class CommentRepository
    {
        public static void AddComment(Comment comment)
        {
            comment.CreationDate = DateTime.Now;
            UserRepository.db.Comments.Add(comment);
            UserRepository.db.SaveChanges();
        }
        public static List<Comment> GetAllComments(int postID)
        {
            return UserRepository.db.Comments.Where(x => x.PostID == postID).ToList();
        }
    }
}