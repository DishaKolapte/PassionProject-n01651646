using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PassionProject_n01651646.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        // A user can have many inquiries
        public ICollection<Inquiry> Inquiries { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
