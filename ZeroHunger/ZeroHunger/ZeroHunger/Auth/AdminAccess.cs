using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; //AuthorizeAttribute belongs to this namespace
using ZeroHunger.EF.Models;

namespace ZeroHunger.Auth
{
    public class AdminAccess : AuthorizeAttribute  //AuthorizeAttribute A class
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (UserLogin)httpContext.Session["user"]; //casting to user
            if (user != null && user.Type == 0) return true;
            else return false;
        }
    }
}