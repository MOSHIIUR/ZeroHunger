using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class ReceiveRequest
    {
        public int ReceiveRequestId { set; get; }
        public string ReceiveLocation { set; get; }
        public DateTime RequestPlacedTime { set; get; }
    }
}