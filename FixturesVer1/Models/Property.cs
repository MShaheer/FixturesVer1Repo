using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class Property
    {
      
            public string ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Location { get; set; }
            public int Accomodates { get; set; }
            public int Price { get; set; }
            public string RoomType { get; set; }
            public string Description { get; set; }
            public int Rating { get; set; }
            public string Owner { get; set; }
            public List<Review> Reviews { get; set; }
     
    }
}