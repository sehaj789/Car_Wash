using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Wash.Models
{
    public class Car
    {
       
     
        public int id { get; set; }
       [Required]
        public string Registration_no { get; set; }
        public string Make  { get; set; }
      
        

    }
}
