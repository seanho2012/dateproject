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
        public UserProfile GetUserProfileByID(string userID)
        {
            string sql = @"SELECT * FROM UserProfile WHERE UserID = @UserID";
            var parameters = new DynamicParameters();

            parameters.Add("UserID", userID);
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                var result = conn.Query<UserProfile>(sql, parameters).FirstOrDefault();
                conn.Close();
                return result;
            }
        }
    }
}
