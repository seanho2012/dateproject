using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Model
{
    public class CallBackLineUserProfile
    {
        /// <summary>
        /// 產生ID_Token的URL
        /// </summary>
        public string iss { get; set; }

        /// <summary>
        /// 產生ID_Token的使用者
        /// </summary>
        public string sub { get; set; }

        /// <summary>
        /// Channel ID
        /// </summary>
        public string aud { get; set; }

        /// <summary>
        /// ID_Token的到期日期（UNIX 時間）
        /// </summary>
        public string exp { get; set; }

        /// <summary>
        /// ID_Token的產生的時間（UNIX 時間）
        /// </summary>
        public string iat { get; set; }

        /// <summary>
        /// The nonce value specified in the authorization URL. Not included if the nonce value was not specified in the authorization request.
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// 使用者使用的身份驗證方法清單
        /// pwd：使用電子郵件和密碼登入
        /// lineautologin：LINE自動登入（包括透過LINE SDK）
        /// lineqr：使用 QR code 登入
        /// linesso:使用 single sign-on 登入
        /// </summary>
        public string[] amr { get; set; }

        /// <summary>
        /// 使用者的顯示名稱
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 使用者的個人資料圖片 URL
        /// </summary>
        public string picture { get; set; }

        /// <summary>
        /// 使用者的電子郵件地址
        /// </summary>
        public string email { get; set; }
    }
}
