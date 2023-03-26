using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF.Models;
using ZeroHunger.EF;
using ZeroHunger.Models;
using ZeroHunger.Auth;
using System.Web.Routing;

namespace ZeroHunger.Controllers
{
    [EmployeeAccess]
    public class EmployeeController : Controller
    {
        private readonly dBCC db = new dBCC();

        // GET: Employee
        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            var user = (UserLogin)HttpContext.Session["user"];
            var UserEmail = user.Email;
            var Employee = (from u in db.Employees
                            where u.EmployeeEmail.Equals(UserEmail)
                            select u).SingleOrDefault();

            var result = (from d in db.Distributes
                          join e in db.Employees on d.EmployeeId equals e.EmployeeId
                          join re in db.Receives on d.ReceiveId equals re.ReceiveRequestId

                          where e.EmployeeId == Employee.EmployeeId
                          select new EmployeeDashboard
                          {
                              AssignedRequestId = d.RequestId,
                              ReceivedStatus = d.CollectedTime,
                              CompletedStatus = d.CompletedTime,
                              ReceiveRequestID = d.ReceiveId

                          }).ToList();

            return View(result);
        }

        public ActionResult ManageTask(int id, int rId)
        {
            Session["OrderId"] = id;
            Session["ReceiveId"] = rId;
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
                              RequestExpiredTime = req.RequestExpiredTime,
                              CollectedTime = d.CollectedTime,
                              ReceivedTime = d.CompletedTime,
                              ReceivedPlace = u.Location,
                              RequestOTP = d.SenderOTP,
                              ReceiverOTP = d.ReceiverOTP,
                              AssignedEmployee = e.EmployeeName
                          }).ToList();


            return View(result);
        }

        [HttpPost]
        public ActionResult ConfirmSenderOTP(FormCollection forms)
        {

            ViewBag.Otp = forms["SenderOTP"];

            string otpValue = forms["SenderOTP"];

            int OTP = int.Parse(otpValue);
            int OrderId = (int)Session["OrderId"];
            int ReceiveId = (int)Session["ReceiveId"];

            var order = (from d in db.Distributes
                         where d.RequestId.Equals(OrderId)
                         select d).SingleOrDefault();

            if (order != null && order.SenderOTP == OTP)
            {
                var Request = (from r in db.Requests
                               where r.Id.Equals(OrderId)
                               select r).SingleOrDefault();

                var Receive = (from r in db.Receives
                               where r.ReceiveRequestId.Equals(ReceiveId)
                               select r).SingleOrDefault();

                Receive.Requeststatus = 2;
                Request.Requeststatus = 2;
                order.CollectedTime = DateTime.Now;
                db.SaveChanges();

                TempData["msg"] = "Collection Success";
                return RedirectToAction("ManageTask", new { id = OrderId, rId = ReceiveId });



            }




            TempData["msg"] = "InValid OTP";
            return RedirectToAction("ManageTask", new { id = OrderId, rId = ReceiveId });


        }
        public ActionResult ConfirmReceiverOTP(FormCollection forms)
        {

                ViewBag.Otp = forms["ReceiverOTP"];

                string otpValue = forms["ReceiverOTP"];

                int OTP = int.Parse(otpValue);
                int OrderId = (int)Session["OrderId"];
                int ReceiveId = (int)Session["ReceiveId"];


            var order = (from d in db.Distributes
                             where d.RequestId.Equals(OrderId)
                             select d).SingleOrDefault();

                if (order != null && order.ReceiverOTP == OTP)
                {
                    var Request = (from r in db.Requests
                                   where r.Id.Equals(OrderId)
                                   select r).SingleOrDefault();

                var user = (UserLogin)HttpContext.Session["user"];
                var UserEmail = user.Email;
                var Employee = (from u in db.Employees
                                    where u.EmployeeEmail.Equals(UserEmail)
                                    select u).SingleOrDefault();

                var Receive = (from r in db.Receives
                               where r.ReceiveRequestId.Equals(ReceiveId)
                               select r).SingleOrDefault();

                Receive.Requeststatus = 3;


                    Employee.EmployeeStatus = 0;
                    Request.Requeststatus = 3;
                    order.CompletedTime = DateTime.Now;
                    db.SaveChanges();


                    TempData["msg"] = "Collection Success";
                    return RedirectToAction("ManageTask", new { id = OrderId, rId = ReceiveId });



                }

                TempData["msg"] = "InValid OTP";
                return RedirectToAction("ManageTask", new { id = OrderId, rId = ReceiveId });



        }
    }
}