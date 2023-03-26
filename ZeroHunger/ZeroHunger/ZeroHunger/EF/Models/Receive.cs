using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Receive
    {
        [Key]
        public int ReceiveRequestId { get; set; }
        public DateTime PlacedTime { get; set; }

        public int Requeststatus { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}