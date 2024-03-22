using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Model
{
    public class Scheduler
    {
        public int SchedulerID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int ColorID { get; set; }

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
