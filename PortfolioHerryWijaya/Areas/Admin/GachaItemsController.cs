using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models.Domain.Portfolio3;

namespace PortfolioHerryWijaya.Areas.Admin
{
    [Area("Admin")]
    public class GachaItemsController : Controller
    {
        private readonly PortfolioDbContext _context;

        public GachaItemsController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GachaItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GachaItems.ToListAsync());
        }

        // GET: Admin/GachaItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaItem = await _context.GachaItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gachaItem == null)
            {
                return NotFound();
            }

            return View(gachaItem);
        }

        // GET: Admin/GachaItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GachaItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GachaItem gachaItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gachaItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gachaItem);
        }

        // GET: Admin/GachaItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaItem = await _context.GachaItems.FindAsync(id);
            if (gachaItem == null)
            {
                return NotFound();
            }
            return View(gachaItem);
        }

        // POST: Admin/GachaItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GachaItem gachaItem)
        {
            if (id != gachaItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gachaItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GachaItemExists(gachaItem.Id))
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
            return View(gachaItem);
        }

        // GET: Admin/GachaItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gachaItem = await _context.GachaItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gachaItem == null)
            {
                return NotFound();
            }

            return View(gachaItem);
        }

        // POST: Admin/GachaItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gachaItem = await _context.GachaItems.FindAsync(id);
            if (gachaItem != null)
            {
                _context.GachaItems.Remove(gachaItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GachaItemExists(int id)
        {
            return _context.GachaItems.Any(e => e.Id == id);
        }
    }
}
