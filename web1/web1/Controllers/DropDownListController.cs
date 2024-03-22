using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web1.Controllers
{
    public class DropDownListController : Controller
    {
        [HttpPost]
        public JsonResult GetLocation()//取得書籍類別下拉選單資料
        {
            try
            {
                List<SelectListItem> locations = new List<SelectListItem>();
                SelectListItem location1 = new SelectListItem();
                SelectListItem location2 = new SelectListItem();
                location1.Value = "1";
                location1.Text = "Location1";
                locations.Add(location1);
                location2.Value = "2";
                location2.Text = "Location2";
                locations.Add(location2);
                return Json(locations);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}