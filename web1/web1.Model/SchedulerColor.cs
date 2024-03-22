using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Model
{
    public class SchedulerColor
    {
        /// <summary>
        /// 系統顏色代號
        /// </summary>顏色代碼
        public int ColorID { get; set; }

        /// <summary>
        /// 顏色名稱
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 顏色代碼
        /// </summary>
        public string ColorKey { get; set; }

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
