using FixturesVer1.Models;
using FixturesVer1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixturesVer1.Controllers
{
    public class HomeController : Controller
    {

          PropertiesService _propertiesService;

        public HomeController()
        {
            _propertiesService = new PropertiesService();
        }

        [HttpGet]
        public ActionResult Index(string location)
        {
            if (location != null)
            {
                return View(_propertiesService.GetPropertiesByLocation(location));
            }
            return View(_propertiesService.GetAllProperties());

        }

   //public JsonResult GetProperties(string house, string sharedRoom, string apartment, int fromValue, int toValue)
   //     {
   //         var properties =  _propertiesService.GetPropertiesByType(house, sharedRoom, apartment, fromValue, toValue);

   //         return Json(new { properties = properties }, JsonRequestBehavior.AllowGet);
   //     }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

 	}
}