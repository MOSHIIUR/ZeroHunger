using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF.Models;
using ZeroHunger.EF;
using ZeroHunger.Models;
using ZeroHunger.Auth;
using System.Web.Security;

namespace ZeroHunger.Controllers
{
    [RestaurentAccess]
    public class HomeController : Controller
    {
        private readonly dBCC db = new dBCC();
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Welcome()
        {
            Session.Clear();

            return View();
        }

        [AllowAnonymous]
        public ActionResult Menu()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(Login obj)
        {
            

            if (ModelState.IsValid)
            {

                var user = (from u in db.UserLogins
                            where u.Email.Equals(obj.Email)
                            && u.Password.Equals(obj.Password)
                            select u).SingleOrDefault();

                if (user != null)
                {
                    Session["user"] = user;
                    var retUrl = Request["ReturnUrl"];
                    //The "ReturnUrl" parameter is typically used to store the URL the user was trying to access before
                    //they were redirected to the login page.
                    if (retUrl != null)
                        return Redirect(retUrl);
                    
                    else if(user.Type == 0)
                        return RedirectToAction("Dashboard", "Request");
                
                    else if(user.Type == 1)
                        return RedirectToAction("Dashboard", "Employee");
                 
                    else if(user.Type == 2) //Food Reciever
                        return RedirectToAction("MakeReceiveRequest", "ReceiveRequest");
                
                    else if(user.Type == 3)
                        return RedirectToAction("MakeRequest");
                
                }


            }



            TempData["Msg"] = "Invalid Credentials";
            return RedirectToAction("Login");
        }
        
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Registration(Restaurent obj)
        {
            db.Restaurents.Add(obj);

            UserLogin user = new UserLogin();
            user.Email = obj.RestaurentEmail;
            user.Password = obj.RestaurentPassword;
            user.Type = 3;
            db.UserLogins.Add(user);

            db.SaveChanges();

            return RedirectToAction("Login");
        }

        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult MakeRequest()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult MakeRequest(Request request)
        {
            var user = (UserLogin)Session["user"];
            var email = user.Email.ToString();

            var RestaurentId = (from u in db.Restaurents
                        where u.RestaurentEmail.Equals(email)
                        select u.RestaurentId).SingleOrDefault();

            Request req = new Request();
            Random random = new Random();

            req.RequestPlacedTime = DateTime.Now;
            req.RequestExpiredTime = request.RequestExpiredTime;
            req.Requeststatus = 0;
            req.RestaurentId = RestaurentId;

            db.Requests.Add(req);
            db.SaveChanges();

            TempData["msg"] = "Request PLaced";
            return View();
        }

        public ActionResult Dashboard()
        {
            var user = (UserLogin)Session["user"];
            var email = user.Email.ToString();

            var RestaurentId = (from u in db.Restaurents
                                where u.RestaurentEmail.Equals(email)
                                select u.RestaurentId).SingleOrDefault();
            
            //show all the rewuest by the restaurent...........

            var Request = (from u in db.Requests
                           where u.RestaurentId == RestaurentId
                           select u);

            return View(Request);
        }

        public ActionResult Details(int id)
        {
            //var email = Session["user"].ToString();



            var result = (from r in db.Restaurents
                         join req in db.Requests on r.RestaurentId equals req.RestaurentId
                         join d in db.Distributes on req.Id equals d.RequestId
                          join rr in db.Receives on d.ReceiveId equals rr.ReceiveRequestId
                          join u in db.Users on rr.UserId equals u.U_Id
                          join e in db.Employees on d.EmployeeId equals e.EmployeeId
                         where req.Id == id
                         select new Detail
                         {
                             OrderId = req.Id,
                             RestaurantName = r.RestaurentName,
                             RestaurantAddress = r.RestaurentAddress,
                             RequestPlacedTime = req.RequestPlacedTime,
                             RequestExpiredTime = req.RequestExpiredTime,
                             RequestOTP = d.SenderOTP,
                             CollectedTime = d.CollectedTime,
                             ReceivedTime = d.CompletedTime,
                             AssignedEmployee = e.EmployeeName,
                             ReceivedPlace = u.Location,
                         }).ToList();



            return View(result);
        }

        [AdminAccess][RestaurentAccess][EmployeeAccess][ReceiverAccess]
        public ActionResult Logout()
        {
            // Invalidate the user's authentication cookie
            // FormsAuthentication.SignOut();

            // Clear any sensitive information from the session
            
            //Session.Clear();
            //Session.RemoveAll();
            //Session.Abandon();
            Session["user"] = "";

            return RedirectToAction("Welcome");
            //Response.Redirect("~/Default.aspx");
        }


    }
}