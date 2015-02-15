using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FixturesVer1.Models;
using FixturesVer1.Services;
using System.IO;

namespace FixturesVer1.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        UsersService _usersService;
        AccountsService _accountssService;
        public UsersController()
        {
            _usersService = new UsersService();
            _accountssService = new AccountsService();
        }

        public ActionResult DashBoard() 
        {
            string userName = User.Identity.Name; 
            var userDetail = _usersService.GetUserById(userName);
            if (userDetail == null || userName == null)
            {
                return View("NoListings");
            }
            else
            {
                ViewBag.image = getImageListOfUser(userName);
                return View(userDetail);
            }
            
        }

        [HttpGet]
        new public ActionResult Profile()
        {
            string userName = User.Identity.Name;
            UsersService _usersservice = new UsersService();
            var user = _usersservice.GetUserById(userName);
            if (user != null)
            {
            PropertiesService propertyservice = new PropertiesService();
           var reviewsByUser= propertyservice.GetReviewsByUserId(userName);
           var propertyList =  propertyservice.GetPropertyListByUserId(userName);
           var reviewsForUser = propertyservice.GetReviewsForUserId(propertyList);

           var referenceByUser = propertyservice.GetReferenceByUserId(userName);
           var referenceAboutUser = propertyservice.GetReferenceAboutUserId(userName);

           
                user.usr_Password = null;
                ProfileViewModel profileViewModel = new ProfileViewModel();
                profileViewModel.reviewByUserList = reviewsByUser;
                profileViewModel.reviewForUserList = reviewsForUser;
                profileViewModel.userModel = user;

               profileViewModel.referenceByUser = referenceByUser;
               profileViewModel.referenceAboutUser = referenceAboutUser;

                return View(profileViewModel);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        new public ActionResult Profile(User userModel)
        {
            string encryptedPass = Utility.Cryptography.Encryption(userModel.usr_Password);
            userModel.usr_Password = encryptedPass;
            bool result = _accountssService.ManageUser(userModel);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(userModel);
            }
        }

        [HttpPost]
        public ActionResult UploadDisplayImage(HttpPostedFileBase file)
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
            var userId = User.Identity.Name;

            var path = Path.Combine(Server.MapPath("~/displayImages/" + "User" + userId + "/"), fileName);
            var directorypath = Server.MapPath("~/displayImages/" + "User" + userId + "/");
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }

            file.SaveAs(path);
            //    }
            //}
            return RedirectToAction("Profile", "Users");
        }

        public ImageViewModel getImageListOfUser(string username)
        {
            var directorypath = Server.MapPath("~/displayImages/" + "User" + username + "/");
           // var relativePath = "~/uploads/" + "Property" + propertyId + "-Detail" + propertyDetailId + "/";

            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }
           
            string ImageName =  Directory.GetFiles(directorypath, "*.*", SearchOption.TopDirectoryOnly).ToList().Last();
            ImageViewModel image = new ImageViewModel();
            //int counter =1;
            String absolutePath = ImageName;

            int relativePathStartIndex = absolutePath.IndexOf("displayImages");
            String relativePath = "../" + absolutePath.Substring(relativePathStartIndex);

            image.src = relativePath; 
            image.altText = username + "Display Picture";
            return image;
        }
         
	}
}