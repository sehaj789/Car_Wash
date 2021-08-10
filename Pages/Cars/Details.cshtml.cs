using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Wash.Data;
using Car_Wash.Models;

namespace Car_Wash.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly Car_Wash.Data.Car_WashContext _context;

        public DetailsModel(Car_Wash.Data.Car_WashContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
