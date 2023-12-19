using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Model;

namespace web1.Dao
{
    public class UserProfileDao : IUserProfileDao
    {
        public UserProfile GetUserData()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM UserProfile";
            using (SqlConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            var result = (from rw in dt.AsEnumerable()
                       select new UserProfile()
                       {
                           UserID = rw["UserID"].ToString(),
                           Account = rw["Account"].ToString(),
                           Password = rw["Password"].ToString(),
                           UserName = rw["UserName"].ToString()
                       }).FirstOrDefault();
            return result;
        }
    }
}
