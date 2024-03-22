using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using web1.Controllers;
using web1.Service;

namespace web1.Attributes
{
    public class BasicAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //    }
        //}
        UserProfileService userProfileService = new UserProfileService();
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            ((BaseController)filterContext.Controller).userInfo = userProfileService.GetUserProfileByID(Convert.ToString(filterContext.HttpContext.Session["UserID"]));
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //Redirecting the user to the Login View of Account Controller  
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Account" },
                     { "action", "LineLogin" }
                });
            }
        }

    }
}