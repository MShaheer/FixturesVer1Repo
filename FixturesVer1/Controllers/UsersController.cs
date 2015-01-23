using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixturesVer1.Controllers
{

    public class UsersController : Controller
    {
        new public ActionResult Profile()
        {
            return View();
        }
	}
}