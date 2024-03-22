using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace web1.Attributes
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public AdminAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            IPrincipal user = httpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            else
            {
                var identity = (ClaimsIdentity)httpContext.User.Identity;
                FormsIdentity id = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
            }
            if(user.Identity.Name == "2") return true;

            return true;
        }

    }
}