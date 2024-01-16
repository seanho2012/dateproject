using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Dao;
using web1.Model;

namespace web1.Service
{
    public class UserProfileService
    {
        private static IUserProfileDao userProfileDao = new UserProfileDao();
        public UserProfile GetUserData()
        {
            return userProfileDao.GetUserData();
        }
    }
}
