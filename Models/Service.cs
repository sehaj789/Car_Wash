using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Wash.Models
{
    public class Service
    {
        public enum service
        {
            Normal, Standared, Best
        }
        public int id { get; set; }
        [Required]
        public string Wash { get; set; }
        public int Price { get; set; }

    }
}
