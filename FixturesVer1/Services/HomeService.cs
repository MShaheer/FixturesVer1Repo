using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixturesVer1.Services
{
    public class HomeService
    { 
        private FixturesDb _db;
        public HomeService()
        {
            _db = new FixturesDb();
        }

    }
}