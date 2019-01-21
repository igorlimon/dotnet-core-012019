using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControllersAndApi.Data;

namespace ControllersAndApi.Controllers
{
    public class ParkingController : Controller
    {
        private readonly ParkingContext _context;

        public ParkingController(ParkingContext context)
        {
            _context = context;
        }

        // GET: Parking
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingLots.ToListAsync());
        }

        // GET: Parking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        // GET: Parking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number")] ParkingLot parkingLot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingLot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingLot);
        }

        // GET: Parking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLots.FindAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return View(parkingLot);
        }

        // POST: Parking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number")] ParkingLot parkingLot)
        {
            if (id != parkingLot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingLot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingLotExists(parkingLot.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkingLot);
        }

        // GET: Parking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        // POST: Parking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingLot = await _context.ParkingLots.FindAsync(id);
            _context.ParkingLots.Remove(parkingLot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingLotExists(int id)
        {
            return _context.ParkingLots.Any(e => e.Id == id);
        }
    }
}
