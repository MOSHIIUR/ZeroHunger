using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF.Models;

namespace ZeroHunger.Auth
{
    public class EmployeeAccess: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (UserLogin)httpContext.Session["user"];
            if (user != null && user.Type == 1) return true;
            else return false;
        }

    }
}