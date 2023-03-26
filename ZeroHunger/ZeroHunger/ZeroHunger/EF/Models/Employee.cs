using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { set; get; }

        [Required]
        public string EmployeeName { set; get; }

        [Required]
        public string EmployeeEmail { set; get; }
        [Required]
        public int Role { set; get; }

        public int EmployeeStatus { set; get; }

        public virtual ICollection<Distribute> Distributes { get; set; }
        public Employee()
        {
            Distributes = new List<Distribute>();
        }

    }
}