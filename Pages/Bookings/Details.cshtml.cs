using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Wash.Data;
using Car_Wash.Models;

namespace Car_Wash.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly Car_Wash.Data.Car_WashContext _context;

        public DetailsModel(Car_Wash.Data.Car_WashContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Booking
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .Include(b => b.Service).FirstOrDefaultAsync(m => m.id == id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
