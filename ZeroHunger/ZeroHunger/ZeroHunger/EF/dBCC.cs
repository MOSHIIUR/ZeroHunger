using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //this line is added
using ZeroHunger.EF.Models; //accessing the models

namespace ZeroHunger.EF
{
    public class dBCC : DbContext //this is inherits
    {
        public DbSet<UserLogin> UserLogins { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Restaurent> Restaurents { get; set; } 
        public DbSet<Request> Requests { get; set; } 
        public DbSet<Receive> Receives { get; set; } 
        public DbSet<Distribute> Distributes { get; set; } 
    
    }
}