using System.Collections.Generic;
using web1.Model;

namespace web1.Dao
{
    public interface ISchedulerDao
    {
        List<SchedulerColor> GetSchedulerColor();
        List<Scheduler> GetSchedulerList();
        bool CreateScheduler(Scheduler scheduler, UserProfile user);

        bool UpdateScheduler(Scheduler scheduler, UserProfile user);
        bool DeleteScheduler(int schedulerID);
    }
}