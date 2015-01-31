using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FixturesVer1.Models;
using FixturesVer1.Services;

namespace FixturesVer1.Controllers
{

    public class UsersController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        new public ActionResult Profile()
        {
           
            return View();
           
        }


        [HttpPost]
        [AllowAnonymous]
        new public ActionResult Profile(User userModel)
        {
            //string encryptedPass = Utility.Cryptography.Encryption(userModel.usr_Password);
            //userModel.usr_Password = encryptedPass;
            return View();

        }
         public ActionResult DashBoard()
        {

            return View();
        }
         
	}
}