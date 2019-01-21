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
    public class IndexModel : PageModel
    {
        private readonly ControllersAndApi.Data.ParkingContext _context;

        public IndexModel(ControllersAndApi.Data.ParkingContext context)
        {
            _context = context;
        }

        public IList<ParkingLot> ParkingLot { get;set; }

        public async Task OnGetAsync()
        {
            ParkingLot = await _context.ParkingLots.ToListAsync();
        }
    }
}
