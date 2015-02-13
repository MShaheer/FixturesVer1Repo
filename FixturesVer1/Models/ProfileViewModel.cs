using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class ProfileViewModel
    {
        public User userModel { get; set; }
        public List<Review> reviewByUserList { get; set; }
        public List<Review> reviewForUserList { get; set; }
        public List<Reference> referenceByUser { get; set; }
        public List<Reference> referenceAboutUser { get; set; }

    }
}