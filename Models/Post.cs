using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int CreatorID { get; set; }
        [Required]
        public string CreatorName { get; set; }
        [Required]
        public int Views { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}