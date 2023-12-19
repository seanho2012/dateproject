using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Dao;

namespace web1.Service
{
    public class ServerInfoService
    {
        web1.Dao.IServerInfoDao serverInfoDao = new ServerInfoDao();
        public string GetServerStatus()
        {
            try
            {
                return serverInfoDao.GetServerStatus();
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}
