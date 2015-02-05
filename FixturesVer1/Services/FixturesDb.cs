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
        //private FixturesDb _db;
        //bool _isDisposed = false;
        public FixturesDb() :base("FixturesVer1DbConn")
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RequestToBook> RequestsToBook { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<PropertyDetail> PropertyDetails { get; set; }
        public DbSet<PropertyAvailableDate> PropertyAvailableDates { get; set; }
               

        /* Not being used 
        public DbContext GetDbContext()
        {
            return this.GetDbContext(false);
        }

        protected virtual DbContext GetDbContext(bool canUseCachedContext)
        {
            if (_db != null)
            {
                if (canUseCachedContext)
                {
                    return _db;
                }
                else
                {
                    _db.Dispose();
                }
            }

            _db = new FixturesDb();

            return _db;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Clear down managed resources.

                    if (_db != null)
                        _db.Dispose();
                }

                _isDisposed = true;
            }
        }
         
        #endregion

         */
    }
}