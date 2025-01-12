using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models.Domain;

namespace PortfolioHerryWijaya.Areas.Admin
{
    [Area("Admin")]
    public class DaysGoneWeaponsController : Controller
    {
        private readonly PortfolioDbContext _context;

        public DaysGoneWeaponsController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DaysGoneWeapons
        public async Task<IActionResult> Index()
        {
            return View(await _context.DaysGoneWeapons.ToListAsync());
        }

        // GET: Admin/DaysGoneWeapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysGoneWeapon = await _context.DaysGoneWeapons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daysGoneWeapon == null)
            {
                return NotFound();
            }

            return View(daysGoneWeapon);
        }

        // GET: Admin/DaysGoneWeapons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DaysGoneWeapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Condition,Source")] DaysGoneWeapon daysGoneWeapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daysGoneWeapon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daysGoneWeapon);
        }

        // GET: Admin/DaysGoneWeapons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysGoneWeapon = await _context.DaysGoneWeapons.FindAsync(id);
            if (daysGoneWeapon == null)
            {
                return NotFound();
            }
            return View(daysGoneWeapon);
        }

        // POST: Admin/DaysGoneWeapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Condition,Source")] DaysGoneWeapon daysGoneWeapon)
        {
            if (id != daysGoneWeapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daysGoneWeapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaysGoneWeaponExists(daysGoneWeapon.Id))
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
            return View(daysGoneWeapon);
        }

        // GET: Admin/DaysGoneWeapons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysGoneWeapon = await _context.DaysGoneWeapons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daysGoneWeapon == null)
            {
                return NotFound();
            }

            return View(daysGoneWeapon);
        }

        // POST: Admin/DaysGoneWeapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daysGoneWeapon = await _context.DaysGoneWeapons.FindAsync(id);
            if (daysGoneWeapon != null)
            {
                _context.DaysGoneWeapons.Remove(daysGoneWeapon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaysGoneWeaponExists(int id)
        {
            return _context.DaysGoneWeapons.Any(e => e.Id == id);
        }
    }
}
