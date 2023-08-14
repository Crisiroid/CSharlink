using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Csharlink.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string AccessType { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Likes { get; set; }
        public int PostNum { get; set; }
        public string Status { get; set; }
    }

}