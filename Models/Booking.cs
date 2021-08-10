using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Wash.Models
{
    public class Booking
    {
        public int id { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public int ServiceID { get; set; }


        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }


        public DateTime Date { get; set; }

    }
}
