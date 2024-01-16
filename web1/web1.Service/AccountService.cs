using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Dao;
using web1.Model;

namespace web1.Service
{
    public class AccountService
    {
        private static LineService lineService = new LineService();
        private static IAccountDao accountDao = new AccountDao();
        public int LoginOrSignup(CallBackLineUserProfile lineProfile)
        {
            int userID;
            try
            {
                userID = lineService.GetUserIDBySub(lineProfile.sub);

                if (userID == 0) 
                {
                    userID = accountDao.CreateNewAccount();
                    lineService.CreateNewLineProfile(lineProfile, userID);
                }

                return userID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
