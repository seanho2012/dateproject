using web1.Model;
namespace web1.Dao
{
    public interface IUserProfileDao
    {
        UserProfile GetUserProfileByID(string userID);
    }
}