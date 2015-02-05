using FixturesVer1.Models;
using FixturesVer1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FixturesVer1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        AccountsService _accountssService;

        public AccountController()
        {
            _accountssService = new AccountsService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //Login action method which displays blank form for authentication.
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // HttpPost Login action method for form posting & authentication. 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginmodel, string returnUrl)
        {
            //var response = c21HttpClient.Authenticate(loginmodel);
            bool isAuthenticated = _accountssService.AuthenticateUser(loginmodel);

            if (isAuthenticated)
            {

                //FormsAuthentication.SetAuthCookie(username, false);
                Utility.CookieHelper.WriteToCookie(loginmodel.usr_Username, loginmodel, loginmodel.remember_Me);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("error", "The user name or password provided is incorrect.");
                // If we got this far, something failed, redisplay form
                return View(loginmodel);
            }

        }
        
        // Logout action method. 
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

        

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User userModel)
        {
            string encryptedPass = Utility.Cryptography.Encryption(userModel.usr_Password);
            userModel.usr_Password = encryptedPass;
            bool result = _accountssService.RegisterUser(userModel);
            if (result)
            {
                return RedirectToAction("Login", "Account");

            }
            else return View();
        }

        [HttpGet]
        public ActionResult Manage()
        {
            string userName = User.Identity.Name;
            UsersService _usersService = new UsersService();
            var user  =_usersService.GetUserById(userName);
            user.usr_Password = null;
            if (user!= null){

                return View(user);
            }
            else{
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Manage(User userModel)
        {
            string encryptedPass = Utility.Cryptography.Encryption(userModel.usr_Password);
            userModel.usr_Password = encryptedPass;
            bool result = _accountssService.ManageUser(userModel);
            if (result)
            {
                return RedirectToAction("Index", "Home");

            }
            else return View(userModel);
        }

	}
}