using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_Wash.Models;

namespace Car_Wash.Data
{
    public class Car_WashContext : DbContext
    {
        public Car_WashContext (DbContextOptions<Car_WashContext> options)
            : base(options)
        {
        }

        public DbSet<Car_Wash.Models.Service> Service { get; set; }

        public DbSet<Car_Wash.Models.Customer> Customer { get; set; }

        public DbSet<Car_Wash.Models.Car> Car { get; set; }

        public DbSet<Car_Wash.Models.Booking> Booking { get; set; }
    }
}
