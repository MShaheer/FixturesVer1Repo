using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FixturesVer1.Models
{
    public class PropertyAvailableDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PropertyId { get; set; }
        public DateTime? Date { get; set; }
        public Property PropertyObj { get; set; }
    }
}