using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class LoginViewModel
    {
        public string usr_Username { get; set; }
        public string usr_Password { get; set; }
        public bool remember_Me { get; set; }
    }
}