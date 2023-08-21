using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public int SenderID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}