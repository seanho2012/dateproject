using System.Collections.Generic;
using web1.Model;

namespace web1.Dao
{
    public interface ILineDao
    {
        LineProfile GetLineUserProfileBySub(string sub);

        bool CreateNewLineProfile(CallBackLineUserProfile lineProfile, int userID);
    }
}