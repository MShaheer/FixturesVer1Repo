using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class User
    {

        [Key]
        [DisplayName("Username")]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[^~`^|=<>]+$", ErrorMessage = "Invalid Characters")]
        [Required]
        public string usr_Username { get; set; }

        [DisplayName("Password")]
        [Required]
        //[RegularExpression("^[^~`^|=<>]+$", ErrorMessage = "Invalid Characters")]
        public string usr_Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public List<Reference> References { get; set; }
        public List<WishList> WishList { get; set; }
        public List<Property> Properties { get; set; }
    }
}