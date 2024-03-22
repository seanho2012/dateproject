using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1.Attributes;
using web1.Model;

namespace web1.Controllers
{
    [BasicAuthenticationFilter]
    public class BaseController : Controller 
    {
        public UserProfile userInfo = new UserProfile();
    }
}