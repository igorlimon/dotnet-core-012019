using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ControllersAndApi.Data;

namespace ControllersAndApi.Pages.ParkingRazorPage
{
    public class CreateModel : PageModel
    {
        private readonly ControllersAndApi.Data.ParkingContext _context;

        public CreateModel(ControllersAndApi.Data.ParkingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ParkingLot ParkingLot { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ParkingLots.Add(ParkingLot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}