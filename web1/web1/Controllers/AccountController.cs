using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using web1.Common;
using web1.Model;
using web1.Service;

namespace web1.Controllers
{
    public class AccountController : Controller
    {

        static ServerInfoService serverInfoService = new ServerInfoService();
        private static LineService lineService = new LineService();
        private static ConfigTool configTool = new ConfigTool();
        private static AccountService accountService = new AccountService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Step.1
        /// 導向Line登入畫面
        /// </summary>
        /// <returns>Line登入連結</returns>
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

        /// <summary>
        /// Step.2
        /// 處理LineCallBack
        /// </summary>
        /// <param name="code">LineLogin-CallBack回傳參數</param>
        /// <param name="state">LineLogin-CallBack回傳參數</param>
        /// <param name="friendship_status_changed">LineLogin-CallBack回傳參數</param>
        /// <param name="liffClientId">LineLogin-CallBack回傳參數</param>
        /// <param name="liffRedirectUri">LineLogin-CallBack回傳參數</param>
        /// <returns></returns>
        public ActionResult LineCallBack(string code, string state, Boolean? friendship_status_changed, string liffClientId, string liffRedirectUri)
        {
            var tokenTask = GetLineIDToken(code);
            var profileTask = GetLineUserInfo(tokenTask.Result.Id_token);
            var callbackData = profileTask.Result;
            int userID = accountService.LoginOrSignup(callbackData);
            Login(userID);
            ViewBag.data = callbackData;
            ViewBag.userID = userID;

            return View();
        }

        /// <summary>
        /// Step.4
        /// 用UserToken取得UserInfo
        /// </summary>
        /// <param name="idToken">UserToken</param>
        /// <returns>CallBackLineUserProfile</returns>
        public async Task<CallBackLineUserProfile> GetLineUserInfo(string idToken)
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
            var result = JsonConvert.DeserializeObject<CallBackLineUserProfile>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            return result;
        }

        /// <summary>
        /// Step.3
        /// 用LineLogin-CallBack取得的UserCode取得UserToken
        /// </summary>
        /// <param name="code">LineLogin-CallBack-UserCode</param>
        /// <returns>LineTokensResponse</returns>
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

        /// <summary>
        /// Step.5
        /// 設定Authorize
        /// </summary>
        /// <param name="userID">UserID</param>
        private void Login(int userID)
        {
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: Convert.ToString(userID), //可以放使用者Id
                issueDate: DateTime.UtcNow,//現在UTC時間
                expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
                    isPersistent: true,// 是否要記住我 true or false
                userData: string.Join(",", "User"), //可以放使用者角色名稱
                cookiePath: FormsAuthentication.FormsCookiePath
            );

            Session["UserID"] = userID;

            var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}