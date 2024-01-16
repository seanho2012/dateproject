using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web1.Service;
using web1.Model;
using web1.Common;

namespace web1.Controllers
{
    public class HomeController : Controller
    {
        ServerInfoService serverInfoService = new ServerInfoService();
        UserProfileService userProfileService = new UserProfileService();
        ConfigTool configTool = new ConfigTool(); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = serverInfoService.GetServerStatus();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        string value;
    }
}