using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Car_Wash.Data;
using Car_Wash.Models;

namespace Car_Wash.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly Car_Wash.Data.Car_WashContext _context;

        public DetailsModel(Car_Wash.Data.Car_WashContext context)
        {
            _context = context;
        }

        public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = await _context.Service.FirstOrDefaultAsync(m => m.id == id);

            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
