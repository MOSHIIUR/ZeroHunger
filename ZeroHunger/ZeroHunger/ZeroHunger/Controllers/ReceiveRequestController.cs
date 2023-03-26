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
    public class ReceiveRequestController : Controller
    {
        private readonly dBCC db = new dBCC();
        // GET: ReceiveRequest
        public ActionResult MakeReceiveRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeReceiveRequest(Receive request)
        {
            var user = (UserLogin)Session["user"];
            var email = user.Email.ToString();

            var UserId = (from u in db.Users
                                where u.Email.Equals(email)
                                select u.U_Id).SingleOrDefault();

            Receive req = new Receive();

            req.PlacedTime = DateTime.Now;
            req.Requeststatus = 0;
            req.UserId = UserId;

            db.Receives.Add(req);
            db.SaveChanges();

            TempData["msg"] = "Request PLaced";
            return View();
        }

        public ActionResult Dashboard()
        {
            var user = (UserLogin)Session["user"];
            var email = user.Email.ToString();

            var UserId = (from u in db.Users
                          where u.Email.Equals(email)
                          select u.U_Id).SingleOrDefault();

            var Request = (from u in db.Receives
                           where u.UserId == UserId
                           select u);

            return View(Request);
        }

        public ActionResult Details(int id)
        {
            //Session["RequestId"] = id;
            var result = (from d in db.Distributes
                          join re in db.Receives on d.ReceiveId equals re.ReceiveRequestId
                          join u in db.Users on re.UserId equals u.U_Id
                          join req in db.Requests on d.RequestId equals req.Id
                          join r in db.Restaurents on req.RestaurentId equals r.RestaurentId
                          //join re in Receives on d.ReceiveId equals re.ReceiveRequestId
                          join e in db.Employees on d.EmployeeId equals e.EmployeeId
                          where re.ReceiveRequestId == id
                          select new Detail
                          {

                              ReceiverID = re.ReceiveRequestId,
                              RequestPlacedTime = re.PlacedTime,
                              ReceiverOTP = d.ReceiverOTP,
                              ReceivedPlace = u.Location,

                              OrderId = req.Id,
                              RestaurantName = r.RestaurentName,
                              RestaurantAddress = r.RestaurentAddress,
                              RequestExpiredTime = req.RequestExpiredTime,
                              CollectedTime = d.CollectedTime,
                              ReceivedTime = d.CompletedTime,
                              //RequestOTP = d.SenderOTP,

                              AssignedEmployee = e.EmployeeName
                          }).ToList();


            return View(result);
        }


    }
}