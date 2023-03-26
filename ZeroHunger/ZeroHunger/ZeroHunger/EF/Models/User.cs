using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class User
    {
        [Key]
        public int U_Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<Receive> Receives { get; set; }
        public User()
        {
            Receives = new List<Receive>();
        }

    }
}