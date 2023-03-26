using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ZeroHunger.CustomValidation;
namespace ZeroHunger.EF.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public DateTime RequestPlacedTime { get; set; }

        [Required]
        public DateTime RequestExpiredTime { get; set; }

        public int Requeststatus { get; set; }

        [ForeignKey("Restaurent")]
        public int RestaurentId { get; set; }
        public virtual Restaurent Restaurent { get; set; }






    }
}