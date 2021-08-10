using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Car_Wash.Data;
using Car_Wash.Models;

namespace Car_Wash.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Car_Wash.Data.Car_WashContext _context;

        public CreateModel(Car_Wash.Data.Car_WashContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarID"] = new SelectList(_context.Car, "id", "Registration_no");
        ViewData["CustomerID"] = new SelectList(_context.Customer, "id", "Name");
        ViewData["ServiceID"] = new SelectList(_context.Service, "id", "Wash");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
