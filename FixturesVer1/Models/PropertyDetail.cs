using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class PropertyDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PropertyId { get; set; }
        public string usr_Username { get; set; }
        public float BasePrice { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CommonFacilities { get; set; }
        public string ExtraFacilities { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Directions { get; set; }
        public bool AdCompleted { get; set; }
       
    }
}