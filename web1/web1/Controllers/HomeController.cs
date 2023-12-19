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
            var test = userProfileService.GetUserData();
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

        public ActionResult LineLogin()
        {
            string lineLoginLink = configTool.GetWebSettingValue("LineLoginUrl");
            string apiParam = "?response_type=code&client_id={0}&redirect_uri={1}&state={2}&scope=profile%20openid%20email";
            apiParam = apiParam.Replace("{0}", configTool.GetWebSettingValue("LineClientID"));
            apiParam = apiParam.Replace("{1}", configTool.GetWebSettingValue("LineCallBackUrl"));
            apiParam = apiParam.Replace("{2}", "12345678");
            lineLoginLink = lineLoginLink.Replace("{0}", apiParam);

            ViewBag.Link = lineLoginLink;

            return View();
        }

        public ActionResult LineCallBack(string code, string state, Boolean? friendship_status_changed, string liffClientId, string liffRedirectUri)
        {
            var tokenTask = GetLineIDToken(code);
            var profileTask = GetLineUserInfo(tokenTask.Result.Id_token);
            var data = profileTask.Result;
            if (data.sub)
            ViewBag.data = data;

            return View();
        }

        public async Task<LineUserProfile> GetLineUserInfo(string idToken)
        {
            var client = new HttpClient();
            string lineProfileLink = configTool.GetWebSettingValue("LineGetProfileUrl");
            string apiParam = "?id_token={0}&client_id={1}";
            apiParam = apiParam.Replace("{0}", idToken);
            apiParam = apiParam.Replace("{1}", configTool.GetWebSettingValue("LineClientID"));
            lineProfileLink = lineProfileLink.Replace("{0}", apiParam);
            var request = new HttpRequestMessage(HttpMethod.Post, lineProfileLink);
            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<LineUserProfile>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            return result;
        }

        public async Task<LineTokensResponse> GetLineIDToken(string code)
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.line.me/oauth2/v2.1/token");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new KeyValuePair<string, string>("client_secret", configTool.GetWebSettingValue("LineClientSecret")));
            collection.Add(new KeyValuePair<string, string>("client_id", configTool.GetWebSettingValue("LineClientID")));
            collection.Add(new KeyValuePair<string, string>("redirect_uri", configTool.GetWebSettingValue("LineCallBackUrl")));
            collection.Add(new KeyValuePair<string, string>("code", code));
            collection.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<LineTokensResponse>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult()); //將 json response 轉成 dto

            return result;
        }
    }
}