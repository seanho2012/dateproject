using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Dao;
using web1.Model;

namespace web1.Service
{
    public class LineService
    {
        private static ILineDao lineDao = new LineDao();

        public int GetUserIDBySub(string sub)
        {
            try
            { 
                var result = lineDao.GetLineUserProfileBySub(sub);
                return result.UserID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool CreateNewLineProfile(CallBackLineUserProfile lineProfile, int userID)
        {
            try
            {
                return lineDao.CreateNewLineProfile(lineProfile, userID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
