using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Restaurent
    {
        [Key]
        public int RestaurentId { get; set; }

        [Required]
        public string RestaurentName { get; set; }

        [Required]
        public string RestaurentEmail { get; set; }

        [Required]
        public string RestaurentAddress { get; set; }


        [Required]
        public string RestaurentPassword { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public Restaurent()
        {
            Requests = new List<Request>();
        }


    }
}