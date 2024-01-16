using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Dao
{
    public class AccountDao : IAccountDao
    {
        public int CreateNewAccount()
        {
            string sql = @"EXEC spCreateNewAccount";
            int userID;
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                userID = conn.Query<int>(sql).FirstOrDefault();
                conn.Close();
            }
            return userID;
        }
    }
}
