using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class Property
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Location { get; set; }
            public int Accomodates { get; set; }
            public int Price { get; set; }
            public string RoomType { get; set; }
            public string Description { get; set; }
            public int Rating { get; set; }
            public string usr_Username { get; set; }
            public string Availability { get; set; }
            public DateTime? AvailabilityFromDate { get; set; }
            public DateTime? AvailabilityToDate { get; set; }
            public List<Review> Reviews { get; set; }
            public PropertyDetail PropertyDetail { get; set; }
            public List<PropertyAvailableDate> AvailableDates { get; set; }
            public User UserObj { get; set; }
    }

}