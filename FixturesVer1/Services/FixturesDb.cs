using FixturesVer1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FixturesVer1.Services
{
    public class FixturesDb :DbContext
    {

        public FixturesDb() :base("FixturesVer1DbConn")
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RequestToBook> RequestsToBook { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishList> WishLists { get; set; }


    }
}