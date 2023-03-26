using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF.Models;
using ZeroHunger.EF;
using ZeroHunger.Models;
using ZeroHunger.Auth;

namespace ZeroHunger.Controllers
{
    [ReceiverAccess]
    public class DistributeController : Controller
    {
        private readonly dBCC db = new dBCC();
        // GET: Distribute
        public ActionResult Homepage()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User obj)
        {
            db.Users.Add(obj);

            UserLogin user = new UserLogin();
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.Type = 2;
            db.UserLogins.Add(user);

            db.SaveChanges();
            TempData["msg"] = "Registrtion Successfull";
            return RedirectToAction("Login", "Home");

        }

        public ActionResult RecievedFood()
        {
            return View();
        }


        public ActionResult Dashboard()
        {
            var user = (UserLogin)Session["user"];
            var email = user.Email.ToString();

            var UserId = (from u in db.Users
                          where u.Email.Equals(email)
                          select u.U_Id).SingleOrDefault();

            return View(Request);
        }


    }
}