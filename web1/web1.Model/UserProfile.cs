using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Model
{
    public class UserProfile
    {
        ///<summary>
        ///使用者ID
        ///</summary>
        [DisplayName("ID")]
        public string UserID { get; set; }
        ///<summary>
        ///使用者帳號
        ///</summary>
        [DisplayName("帳號")]
        public string Account { get; set; }
        ///<summary>
        ///使用者密碼
        ///</summary>
        [DisplayName("密碼")]
        public string Password { get; set; }
        ///<summary>
        ///使用者名稱
        ///</summary>
        [DisplayName("名稱")]
        public string UserName { get; set; }
    }
}
