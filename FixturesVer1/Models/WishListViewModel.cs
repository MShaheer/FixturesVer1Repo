using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class WishListViewModel
    {
        [Key]
        public int ID { get; set; }
        public WishList Wish { get; set; }
        public Property WishListProperty { get; set; }
    }
}