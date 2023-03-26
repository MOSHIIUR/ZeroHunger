using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ZeroHunger.EF.Models;
using ZeroHunger.EF;
using ZeroHunger.Auth;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        private readonly dBCC db = new dBCC();
        public ActionResult Homepage()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost] 
        [AllowAnonymous]
        public ActionResult AddEmployee(Employee obj)
        {
            db.Employees.Add(obj);

            UserLogin user = new UserLogin();
            Random ran = new Random();
            user.Email = obj.EmployeeEmail;
            user.Password = Guid.NewGuid().ToString().Substring(6);
            user.Type = 1;

            db.UserLogins.Add(user);


            db.SaveChanges();

            return RedirectToAction("Login", "Home");
        }

    }
}