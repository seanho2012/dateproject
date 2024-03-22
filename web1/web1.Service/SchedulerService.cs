using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web1.Dao;
using web1.Model;

namespace web1.Service
{
    public class SchedulerService
    {
        private static ISchedulerDao schedulerDao = new SchedulerDao();
        public List<SchedulerColor> GetSchedulerColor()
        {
            return schedulerDao.GetSchedulerColor();
        }

        public List<Scheduler> GetSchedulerList()
        {
            return schedulerDao.GetSchedulerList();
        }

        public bool CreateScheduler(Scheduler scheduler, UserProfile user)
        {
            return schedulerDao.CreateScheduler(scheduler, user);
        }

        public bool UpdateScheduler(Scheduler scheduler, UserProfile user)
        {
            return schedulerDao.UpdateScheduler(scheduler, user);
        }

        public bool DeleteScheduler(int schedulerID)
        {
            return schedulerDao.DeleteScheduler(schedulerID);
        }
    }
}
