using FixturesVer1.Models;
using FixturesVer1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using Mvc.Mailer;

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
            if (location == "" || location == null)
            {
                return View(_propertiesService.GetAllProperties());
                
            }
            else 
            {
                return View(_propertiesService.GetPropertiesByLocation(location));
            }

        }

        public JsonResult GetProperties(string rent, string sell, string share, int fromValue, int toValue)
        {
            var properties =  _propertiesService.GetPropertiesByType(rent, sell, share, fromValue, toValue);

            return Json(new { properties = properties }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddToWishList(int propertyId)
        {
            var username = User.Identity.Name;
            _propertiesService.AddToWishList(propertyId, username);

            return Json(new { IsAddToWishList = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWishList()
        {
            var username = User.Identity.Name;
            List<WishList> wishlist= _propertiesService.GetWishListByUserId(username);
            List<WishListViewModel> wishListViewModel = new List<WishListViewModel>();
            int counter = 1;
            foreach(var wish in wishlist)
            {
                wish.ID = counter;
                var propertyObj = _propertiesService.GetPropertyByPropertyId(wish.PropertyId);
                wishListViewModel.Add(new WishListViewModel { WishListProperty = propertyObj, Wish =wish });
            }

            return View(wishListViewModel);
        }

        public ActionResult Detail(int id)
        {
            var property = _propertiesService.GetPropertyById(id);
            var propertyDetail = _propertiesService.GetPropertyDetailByPropertyId(id);

            if (propertyDetail.Availability == "sometime")
            {
                propertyDetail.AvailabilityDateString = _propertiesService.GetSometimeAvailableDates(id);
            }

            ViewBag.commonFacililities = propertyDetail.CommonFacilities.Split(',');
            ViewBag.extraFacililities = propertyDetail.ExtraFacilities.Split(',');
            var imageList = getImageListOfProperty(id, propertyDetail.ID);

            foreach(var image in imageList){
                image.src = image.src.Substring(2);
            }

            ViewBag.imageList = imageList;

            return View(property);
        }

        public ActionResult ContactOwner(int propertyId, string userEmail, string message) 
        {
            var ownerEmail = _propertiesService.GetOwnerEmail(propertyId);

            var _mailer = new MvcMailMessage();
            _mailer.Subject = "Message From The Fixtures App";
            _mailer.To.Add(ownerEmail);
            _mailer.Body = message;
            _mailer.Send();

            return Json(new { messageIsSent = true }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetReviews(int propertyID)
        {
            var reviews = _propertiesService.GetReviews(propertyID);

            return Json(new { reviews = reviews }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SubmitReview(string userName, int rating, string review, int propertyID, string propertyName)
        {
            _propertiesService.SubmitReview(userName, rating, review, propertyID, propertyName);

            return Json(new { isReviewSubmitted = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PostAd()
        {
            ViewBag.Type = TypeComboData();
            ViewBag.PropertyType = PropertyTypeComboData();
            return View();
        }

        [HttpPost]
        public ActionResult PostAd(Property propertyForm)
        {
            propertyForm.usr_Username = User.Identity.Name;
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
            ViewBag.imageList = getImageListOfProperty(propertyId.Value,propertyDetail.ID);
            //propertyDetail.CommonFacilities.Trim("\r\n");
            return View("ManageListing",propertyDetail);
            }
        }

        [HttpGet]
        public ActionResult ManageListing(int? propertyId=null)
        {
            var propertyDetail =  _propertiesService.GetPropertyDetailByPropertyId(propertyId);
            if(propertyDetail == null || propertyId == null)
            {
                return View("NoListings");
            }
            else
            {
            ViewBag.imageList = getImageListOfProperty(propertyId.Value, propertyDetail.ID);
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


        [HttpPost]
        public ActionResult UploadImages(HttpPostedFileBase file, string propertyId, string propertyDetailId)
        {
            //foreach (var file in files)
            //{
            //    if (file.ContentLength > 0)
            //    {
                    //var fileName = Path.GetFileName(file.FileName);
                    var fileName = DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + User.Identity.Name;
                    fileName += DateTime.Today.Ticks.ToString("0");
                    fileName += Path.GetFileName(file.FileName);
            //fileName += DateTime.Today..ToString();

                   
                    var path = Path.Combine(Server.MapPath("~/uploads/" +"Property"+ propertyId+"-Detail"+propertyDetailId+"/"), fileName);
                    var directorypath = Server.MapPath("~/uploads/" + "Property" + propertyId + "-Detail" + propertyDetailId + "/");
                    if (!Directory.Exists(directorypath))
                    {
                        Directory.CreateDirectory(directorypath);
                    }

                    file.SaveAs(path);
            //    }
            //}
            return RedirectToAction("BrowseListing","Properties");
        }

        public List<ImageViewModel> 
            getImageListOfProperty(int propertyId, int propertyDetailId)
        {
            var directorypath = Server.MapPath("~/uploads/" + "Property" + propertyId + "-Detail" + propertyDetailId + "/");
           // var relativePath = "~/uploads/" + "Property" + propertyId + "-Detail" + propertyDetailId + "/";

            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }
           
            List<string> ImageNames =  Directory.GetFiles(directorypath, "*.*", SearchOption.TopDirectoryOnly).ToList();
            List<ImageViewModel> imageList = new List<ImageViewModel>();
            int counter =1;
            foreach(var item in ImageNames)
            {
                String absolutePath = item;
                int relativePathStartIndex = absolutePath.IndexOf("uploads");
                String relativePath ="../"+ absolutePath.Substring(relativePathStartIndex);
                imageList.Add(new ImageViewModel { src = relativePath, altText = counter.ToString() });
            counter++;
            }

            return imageList;
        
        }

        //[HttpPost]
        //public ActionResult UploadImages(IEnumerable<HttpPostedFileBase> files)
        //{
        //    foreach (var file in files)
        //    {
        //        if (file.ContentLength > 0)
        //        {
        //    var fileName = Path.GetFileName(file.FileName);
        //    fileName = DateTime.Today.ToString() + User.Identity.Name;
        //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        //    file.SaveAs(path);
        //        }
        //    }
        //    return RedirectToAction("BrowseListing", "Properties");
        //}





        public List<SelectListItem> TypeComboData()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Rent", Value = "Rent" });

            items.Add(new SelectListItem { Text = "Sell", Value = "Sell" });

            items.Add(new SelectListItem { Text = "Share", Value = "Share", Selected = true });
            
            return items;
        }

        public List<SelectListItem> PropertyTypeComboData()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "House", Value = "House" });

            items.Add(new SelectListItem { Text = "Apartment", Value = "Apartment" });

            items.Add(new SelectListItem { Text = "Villa", Value = "Villa", Selected = true });

            items.Add(new SelectListItem { Text = "Mansion", Value = "Mansion" });

            items.Add(new SelectListItem { Text = "Farmhouse", Value = "Farmhouse" });

            items.Add(new SelectListItem { Text = "Bunglow", Value = "Bunglow", Selected = true });

            items.Add(new SelectListItem { Text = "Duplex", Value = "Duplex", Selected = true });

            return items;
        }





	}
}