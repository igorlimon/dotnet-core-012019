using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ControllersAndApi.Data;

namespace ControllersAndApi.Pages.ParkingRazorPage
{
    public class DetailsModel : PageModel
    {
        private readonly ControllersAndApi.Data.ParkingContext _context;

        public DetailsModel(ControllersAndApi.Data.ParkingContext context)
        {
            _context = context;
        }

        public ParkingLot ParkingLot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingLot = await _context.ParkingLots.FirstOrDefaultAsync(m => m.Id == id);

            if (ParkingLot == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
