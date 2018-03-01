using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eStoreServices.Models
{
    public class Pattern
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string RealPower { get; set; }
        public string ActivePower { get; set; }
    }
}