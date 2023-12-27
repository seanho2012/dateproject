using Dapper;
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
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                return conn.Query<UserProfile>(sql).FirstOrDefault();
                //conn.Close();
            }
        }
    }
}
