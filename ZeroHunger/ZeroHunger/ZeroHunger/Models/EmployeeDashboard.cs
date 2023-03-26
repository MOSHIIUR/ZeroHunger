using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class EmployeeDashboard
    {
        public int AssignedRequestId { get; set; }
        public int ReceiveRequestID { get; set; }
        public DateTime? ReceivedStatus { get; set; }
        public DateTime? CompletedStatus { get; set; }
    }
}