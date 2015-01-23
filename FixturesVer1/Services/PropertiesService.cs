using FixturesVer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixturesVer1.Services
{
    public class PropertiesService
    {
        private FixturesDb _db;
        public PropertiesService()
        {
            _db = new FixturesDb();
        }

        public List<Property> GetAllProperties()
        {
            return _db.Properties.ToList();
        }

        public List<Property> GetPropertiesByLocation(string location)
        {
            return _db.Properties.Where(p => p.Location == location).ToList();
        }

        public void AddProperty(Property property)
        {
            _db.Properties.Add(property);

            _db.SaveChanges();
        }
    }
}