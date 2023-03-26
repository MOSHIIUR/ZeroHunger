using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Distribute
    {
        [Key]
        public int DistributeId { get; set; } // == RequestID



        public DateTime? CollectedTime { get; set; }
        public DateTime? CompletedTime { get; set; }

        public int? SenderOTP { get; set; }
        public int? ReceiverOTP { get; set; }




        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }

        [ForeignKey("Receive")]
        public int ReceiveId { get; set; }
        public virtual Receive Receive { get; set; }



    }
}