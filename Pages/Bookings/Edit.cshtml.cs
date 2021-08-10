using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car_Wash.Data;
using Car_Wash.Models;

namespace Car_Wash.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly Car_Wash.Data.Car_WashContext _context;

        public EditModel(Car_Wash.Data.Car_WashContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CarID"] = new SelectList(_context.Car, "id", "Registration_no");
           ViewData["CustomerID"] = new SelectList(_context.Customer, "id", "Name");
           ViewData["ServiceID"] = new SelectList(_context.Service, "id", "Wash");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.id == id);
        }
    }
}
