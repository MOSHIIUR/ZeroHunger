using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Detail
    {
        public int OrderId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public DateTime RequestPlacedTime { get; set; }
        public DateTime RequestExpiredTime { get; set; }
        public int? RequestOTP { get; set; }
        public int? ReceiverOTP { get; set; }
        public string AssignedEmployee { get; set; }
        public string ReceivedPlace { get; set; }
        public int ReceiverID { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public DateTime? CollectedTime { get; set; }
    }
}