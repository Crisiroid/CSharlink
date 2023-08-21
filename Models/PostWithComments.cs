using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public class PostWithComments
    {
        public Post post { get; set; }
        public List<Comment> comments { get; set; }
    }
}