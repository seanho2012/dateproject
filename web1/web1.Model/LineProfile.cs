using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Model
{
    public class LineProfile
    {
        /// <summary>
        /// LineProfileID
        /// </summary>
        public int LineProfileID { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 產生ID_Token的使用者
        /// </summary>
        public string sub { get; set; }

        /// <summary>
        /// Channel ID
        /// </summary>
        public string aud { get; set; }

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

        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 創建人員
        /// </summary>
        public string CreatedUser { get; set; }

        /// <summary>
        /// 異動時間
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// 異動人員
        /// </summary>
        public string ModifiedUser { get; set; }
    }
}
