using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ZeroHunger.EF;
using ZeroHunger.EF.Models;
using ZeroHunger.Models;
using ZeroHunger.Auth;

namespace ZeroHunger.Controllers
{
    [AdminAccess]
    public class RequestController : Controller
    {
        private readonly dBCC db = new dBCC();
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var Request = (from u in db.Requests
                           select u);
            return View(Request);
        }


        public ActionResult AssignEmployee(int id)
        {
            Session["RequestID"] = id;

            var employees = (from u in db.Employees
                             where u.EmployeeStatus == 0
                             select new EmployeeAvailable { EmployeeName = u.EmployeeName, EmployeeId = u.EmployeeId });

            return View(employees);
        }
        public ActionResult AssignEmp(int id)
        {
            Session["empId"] = id;
            return RedirectToAction("Distribute");
            
        }

        public ActionResult Distribute()
        {
            var receiveRequest =  from r in db.Receives
                                  join u in db.Users on r.UserId equals u.U_Id
                                  where r.Requeststatus == 0
                                  orderby r.PlacedTime ascending
                                  select new ReceiveRequest
                                  {
                                      ReceiveLocation = u.Location,
                                      RequestPlacedTime = r.PlacedTime,
                                      ReceiveRequestId = r.ReceiveRequestId
                                  };

            return View(receiveRequest);

        }

        public ActionResult CompleteDistribution(int id)
        {
            int empId = (int)Session["empId"];
            int requestId = (int)Session["RequestID"];
            var emp = (from u in db.Employees
                       where u.EmployeeId == empId
                       select u).SingleOrDefault();

            emp.EmployeeStatus = 1;

       
            var r = (from u in db.Receives
                       where u.ReceiveRequestId == id
                       select u).SingleOrDefault();

            r.Requeststatus = 1;

            var req = (from u in db.Requests
                       where u.Id == requestId
                       select u).SingleOrDefault();

            req.Requeststatus = 1;


            Distribute d = new Distribute();
            Random random = new Random();

            d.ReceiveId = r.ReceiveRequestId;
            d.EmployeeId = empId;
            d.RequestId = requestId;
            d.SenderOTP = random.Next(100000, 999999);
            d.ReceiverOTP = random.Next(100000, 999999);

            db.Distributes.Add(d);

            db.SaveChanges();

            Session["RequestID"] = "";
            Session["empId"] = "";

            //TempData["msg"] = "Successfully Assigned";
            return RedirectToAction("Dashboard");
        }

        public ActionResult Details(int id)
        {
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
                              AssignedEmployee = e.EmployeeName,
                          }).ToList();


            return View(result);
        }

    }
}