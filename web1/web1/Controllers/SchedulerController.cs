using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web1.Model;
using web1.Service;

namespace web1.Controllers
{
    public class SchedulerController : BaseController
    {
        private static SchedulerService schedulerService = new SchedulerService();

        [HttpPost()]
        public JsonResult GetScheduler()
        {
            try
            {
                List<Scheduler> schedulers = schedulerService.GetSchedulerList();
                Console.Write(userInfo.UserID);
                return Json(schedulers);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost()]
        public JsonResult CreateScheduler(Scheduler data)
        {
            try
            {
                return Json(schedulerService.CreateScheduler(data, userInfo));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost()]
        public JsonResult UpdateScheduler(Scheduler data)
        {
            try
            {
                return Json(schedulerService.UpdateScheduler(data, userInfo));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost()]
        public JsonResult DeleteScheduler(int schedulerID)
        {
            try
            {
                return Json(schedulerService.DeleteScheduler(schedulerID));
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost()]
        public JsonResult GetSchedulerColor()
        {
            try
            {
                List<SchedulerColor> colors = schedulerService.GetSchedulerColor();

                return Json(colors);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}