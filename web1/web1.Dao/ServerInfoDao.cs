﻿using Dapper;
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
            string sql = @"SELECT * FROM fnGetServerStatus()", result;
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                result = conn.Query<string>(sql).FirstOrDefault();
                conn.Close();
            }
            return result;
        }
    }
}
