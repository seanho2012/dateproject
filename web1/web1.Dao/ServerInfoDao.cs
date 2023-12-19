using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web1.Dao
{
    public class ServerInfoDao : IServerInfoDao
    {
        public string GetServerStatus()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM fnGetServerStatus()";
            using (SqlConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return dt.Rows[0]["ServerStatus"].ToString();
        }
    }
}
