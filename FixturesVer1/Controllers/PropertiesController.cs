using FixturesVer1.Models;
using FixturesVer1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixturesVer1.Controllers
{
    [Authorize]
    public class PropertiesController : Controller
    {
        PropertiesService _propertiesService;

        public PropertiesController()
        {
            _propertiesService = new PropertiesService();
        }


        public ActionResult Listing(string location)
        {
            if (location != null)
            {
                return View(_propertiesService.GetPropertiesByLocation(location));
            }
            return View(_propertiesService.GetAllProperties());
        }

        [HttpGet]
        public ActionResult PostAd()
        {
            ViewBag.Type = PropertyTypeComboData();
            return View();
        }

        [HttpPost]
        public ActionResult PostAd(Property propertyForm)
        {
            _propertiesService.AddProperty(propertyForm);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult BrowseListing()
        {
            List<Property> propertiesList  = _propertiesService.GetPropertyListByUserId(User.Identity.Name);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            
            foreach(var item in propertiesList)
            {
               selectListItems.Add(new SelectListItem {  Value = item.ID.ToString() , Text = item.Name });
            }
           
            ViewBag.propertiesList = selectListItems; 

            return View();

        }

        [HttpPost]
        public ActionResult BrowseListing(int? propertyId)
        {
            if (propertyId == null)
            {
                return View("NoListings");
            }
            else
            { 
            var propertyDetail = _propertiesService.GetPropertyDetailByPropertyId(propertyId);
            return View("ManageListing",propertyDetail);
            }
        }

        [HttpGet]
        public ActionResult ManageListing(int? propertyId=null)
        {
            var propertyDetail =  _propertiesService.GetPropertyDetailByPropertyId(propertyId);
            if(propertyDetail == null)
            {
                return View("NoListings");
            }
            else
            { 
            return View(propertyDetail);
            }
        }

        [HttpPost]
        public ActionResult ManageListing(PropertyDetail propertyDetail)
        {
            if (_propertiesService.UpdatePropertyDetailByDetailId(propertyDetail))
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View(propertyDetail);
            
        }














        public List<SelectListItem> PropertyTypeComboData()
        {

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Apartment", Value = "0" });

            items.Add(new SelectListItem { Text = "House", Value = "1" });

            items.Add(new SelectListItem { Text = "Bed & Breakfast", Value = "2", Selected = true });

            items.Add(new SelectListItem { Text = "Villa", Value = "3" });

            items.Add(new SelectListItem { Text = "Other", Value = "4" });



            return items;

        }

        

	}
}