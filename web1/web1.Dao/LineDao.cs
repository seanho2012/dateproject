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
    public class LineDao : ILineDao
    {
        /// <summary>
        /// 取得LineProfile
        /// </summary>
        /// <param name="sub">產生ID_Token的使用者</param>
        /// <returns>LineProfile</returns>
        public LineProfile GetLineUserProfileBySub(string sub)
        {
            string sql = @"SELECT * FROM LineProfile WHERE sub = @sub";
            var parameters = new DynamicParameters();

            parameters.Add("sub", sub);
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                var result = conn.Query<LineProfile>(sql, parameters).FirstOrDefault();
                conn.Close();
                return result;
            }
        }
        /// <summary>
        /// 新增LineProfile
        /// </summary>
        /// <param name="lineProfile"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool CreateNewLineProfile(CallBackLineUserProfile lineProfile, int userID)
        {
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                using(var trans = conn.BeginTransaction())
                {
                    var result = conn.Execute(GetCreateLineProfileSQL(), new
                    {
                        sub = lineProfile.sub,
                        aud = lineProfile.aud,
                        name = lineProfile.name,
                        picture = lineProfile.picture,
                        email = lineProfile.email,
                        UserID = userID,
                        CreatedDate = DateTime.Now,
                        CreatedUser = "System",
                        ModifiedDate = DateTime.Now,
                        ModifiedUser = "System"
                    },trans);
                    trans.Commit();
                }
                conn.Close();
                return true;
            }
        }

        private string GetCreateLineProfileSQL()
        {
            string sql = @"
                INSERT INTO [dbo].[LineProfile] (sub,aud,name,picture,email,UserID,CreatedDate,CreatedUser,ModifiedDate,ModifiedUser) 
                VALUES(
                    @sub
                    , @aud
                    , @name
                    , @picture
                    , @email
                    , @UserID
                    , @CreatedDate
                    , @CreatedUser
                    , @ModifiedDate
                    , @ModifiedUser
                )";
            return sql;
        }
    }
}
