using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Model;
using Dapper;

namespace web1.Dao
{
    public class SchedulerDao : ISchedulerDao
    {
        public List<SchedulerColor> GetSchedulerColor()
        {
            string sql = @"SELECT ColorID,ColorName,ColorKey FROM SchedulerColor";
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                return conn.Query<SchedulerColor>(sql).ToList();
                //conn.Close();
            }
        }

        public List<Scheduler> GetSchedulerList()
        {
            string sql = @"SELECT SchedulerID, StartTime, EndTime, Title, Description, Location, ColorID FROM Scheduler";
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                return conn.Query<Scheduler>(sql).ToList();
                //conn.Close();
            }
        }

        public bool CreateScheduler(Scheduler scheduler,UserProfile user)
        {
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var result = conn.Execute(GetCreateSchedulerSQL(), new
                    {
                        StartTime = scheduler.StartTime,
                        EndTime = scheduler.EndTime,
                        Title = scheduler.Title,
                        Description = scheduler.Description,
                        Location = scheduler.Location,
                        ColorID = scheduler.ColorID,
                        CreatedDate = DateTime.Now,
                        CreatedUser = user.UserName,
                        ModifiedDate = DateTime.Now,
                        ModifiedUser = user.UserName
                    }, trans);
                    trans.Commit();
                }
                conn.Close();
                return true;
            }
        }

        public bool UpdateScheduler(Scheduler scheduler, UserProfile user)
        {
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var result = conn.Execute(GetUpdateSchedulerSQL(), new
                    {
                        StartTime = scheduler.StartTime,
                        EndTime = scheduler.EndTime,
                        Title = scheduler.Title,
                        Description = scheduler.Description,
                        Location = scheduler.Location,
                        ColorID = scheduler.ColorID,
                        SchedulerID = scheduler.SchedulerID,
                        ModifiedDate = DateTime.Now,
                        ModifiedUser = user.UserName
                    }, trans);
                    trans.Commit();
                }
                conn.Close();
                return true;
            }
        }

        public bool DeleteScheduler(int schedulerID)
        {
            using (IDbConnection conn = new SqlConnection(Common.ConfigTool.GetDBConnectionString()))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var result = conn.Execute(GetDeleteSchedulerSQL(), new
                    {
                        SchedulerID = schedulerID
                    }, trans);
                    trans.Commit();
                }
                conn.Close();
                return true;
            }
        }

        private string GetCreateSchedulerSQL()
        {
            string sql = @"
                INSERT INTO [dbo].[Scheduler] (StartTime, EndTime, Title, Description, Location, ColorID, CreatedDate, CreatedUser, ModifiedDate, ModifiedUser) 
                VALUES(
                    @StartTime
                    , @EndTime
                    , @Title
                    , @Description
                    , @Location
                    , @ColorID
                    , @CreatedDate
                    , @CreatedUser
                    , @ModifiedDate
                    , @ModifiedUser
                )";
            return sql;
        }

        private string GetUpdateSchedulerSQL()
        {
            string sql = @"
                UPDATE [dbo].[Scheduler] SET
                    StartTime = @StartTime
                    , EndTime = @EndTime
                    , Title = @Title
                    , Description = @Description
                    , Location = @Location
                    , ColorID = @ColorID
                    , ModifiedDate = @ModifiedDate
                    , ModifiedUser = @ModifiedUser
                WHERE SchedulerID = @SchedulerID";
            return sql;
        }

        private string GetDeleteSchedulerSQL()
        {
            string sql = @"
                DELETE FROM [dbo].[Scheduler]
                WHERE SchedulerID = @SchedulerID";
            return sql;
        }
    }
}
