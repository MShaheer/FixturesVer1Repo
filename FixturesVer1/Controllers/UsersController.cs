using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FixturesVer1.Models;
using FixturesVer1.Services;

namespace FixturesVer1.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        AccountsService _accountssService;
        public UsersController()
        {

            _accountssService = new AccountsService();
        }

        public ActionResult DashBoard() 
        {
            return View();
        }

        [HttpGet]
        new public ActionResult Profile()
        {
            string userName = User.Identity.Name;
            UsersService _usersservice = new UsersService();
            var user = _usersservice.GetUserById(userName);
           
            if (user != null)
            {
                user.usr_Password = null;
                return View(user);
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
         
	}
}