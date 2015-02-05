using FixturesVer1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            int id = property.ID;
            _db.PropertyDetails.Add(new PropertyDetail { PropertyId = property.ID, AdCompleted = false , usr_Username = property.usr_Username ,   }) ; 
            _db.SaveChanges();
        }

        public List<Property> GetPropertyListByUserId(string usr_userName)
        {
            return _db.Properties.Where(p => p.usr_Username == usr_userName).ToList();
            
        }

        public List<Property> GetPropertyListByType(string type)
        {
            return _db.Properties.Where(p => p.Type == type).ToList();

        }

        public PropertyDetail GetPropertyDetailByPropertyId(int propertyId)
        {
            return _db.PropertyDetails.Where(p => p.PropertyId == propertyId).ToList().FirstOrDefault();

        }

        public bool UpdatePropertyDetailByDetailId(PropertyDetail propertyDetail)
        {
            _db.Entry(propertyDetail).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }

    }
}