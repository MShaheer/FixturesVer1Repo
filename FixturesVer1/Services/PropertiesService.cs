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

        public Property GetPropertyById(int id)
        {
            return _db.Properties.Where(p => p.ID == id).FirstOrDefault();
        }

        public List<Property> GetPropertiesByLocation(string location)
        {
            return _db.Properties.Where(p => p.Location == location).ToList();
        }

        public List<Property> GetPropertiesByType(string house, string sharedRoom, string apartment, int fromValue, int toValue)
        {
            if (house == "" && sharedRoom == "" && apartment == "")
            {
                return _db.Properties.Where(p => p.Price >= fromValue && p.Price <= toValue).ToList();
            }
            return _db.Properties.Where(p => (p.Type == house || p.Type == sharedRoom || p.Type == apartment) && (p.Price >= fromValue && p.Price <= toValue)).ToList();
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

        public PropertyDetail GetPropertyDetailByPropertyId(int? propertyId)
        {
            string usr_userName = HttpContext.Current.User.Identity.Name;
            List<Property> propertyList = new List<Property>();
           
            if(propertyId==null)
            {
                propertyList = GetPropertyListByUserId(usr_userName);
                if(propertyList.Count==0)
                {
                    return null;
                }
                else {
                    Property property = propertyList.FirstOrDefault();
                    return _db.PropertyDetails.Where(p => p.PropertyId == property.ID).ToList().FirstOrDefault();
                }
            }
            else
            {
                int intPropertyID = Convert.ToInt32(propertyId);
                return _db.PropertyDetails.Where(p => p.PropertyId == intPropertyID).ToList().FirstOrDefault();
            }
         

        }

        public bool UpdatePropertyDetailByDetailId(PropertyDetail propertyDetail)
        {

            if(propertyDetail.Availability == "sometime")
            {
               string[] dates= propertyDetail.AvailabilityDateString.Split(new char[] {','});

                foreach(var item in dates)
                {
                    DateTime date=Convert.ToDateTime(item);
                    int count = _db.PropertyAvailableDates.Where(p => p.PropertyId == propertyDetail.PropertyId && p.Date == date).Count();
                    
                    if(count <= 0)
                    {
                        _db.PropertyAvailableDates.Add(new PropertyAvailableDate { PropertyId = propertyDetail.PropertyId, Date = Convert.ToDateTime(item) });
                    }
                   
                }
            }
            Property property = _db.Properties.Where(p => p.ID == propertyDetail.PropertyId).ToList().FirstOrDefault();
            property.Price = propertyDetail.BasePrice;
            property.Location = propertyDetail.StreetAddress1 + "," + propertyDetail.City + "," + propertyDetail.State + "," + propertyDetail.Country;
            property.Availability = propertyDetail.Availability;
            property.Description = propertyDetail.Description;
           // property.Name = propertyDetail.Title;
            _db.Entry(property).State = EntityState.Modified;
            _db.Entry(propertyDetail).State = EntityState.Modified;
            _db.SaveChanges();
            return true;
        }

        public List<Review> GetReviewsByUserId(string usr_username)
        {
            return _db.Reviews.Where(p => p.PostedBy == usr_username).ToList();
        }

        public List<Review> GetReviewsForUserId(List<Property> propertyList)
        {
            List<Review> reviewsList = new List<Review>();
            foreach(var property in propertyList)
            {

            reviewsList.Add(_db.Reviews.Where(p => p.PropertyId == property.ID).ToList().FirstOrDefault());
            }
            return reviewsList;

        }
        public List<Reference> GetReferenceByUserId(string usr_username)
        {
            return _db.References.Where(p => p.PostedBy == usr_username).ToList();
        }
        public List<Reference> GetReferenceAboutUserId(string usr_username)
        {
            return _db.References.Where(p => p.PostedFor == usr_username).ToList();
            
        }

        internal void SubmitReview(string userName, int rating, string reviewBody, int propertyID, string propertyName)
        {
            var review = new Review { 
                PostedBy = userName,
                Body = reviewBody,
                DatePosted = DateTime.Now,
                PropertyId = propertyID,
                PropertyName = propertyName,
                ReviewRating = rating
            };

            _db.Reviews.Add(review);
            _db.SaveChanges();
        }
    }

}