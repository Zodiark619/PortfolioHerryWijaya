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
    public class GachasController : Controller
    {
        private readonly PortfolioDbContext _context;

        public GachasController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Gachas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gachas.ToListAsync());
        }

        // GET: Admin/Gachas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gacha = await _context.Gachas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gacha == null)
            {
                return NotFound();
            }

            return View(gacha);
        }

        // GET: Admin/Gachas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gachas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GachaItems,GachaItemPercentages,ImageUrl,Description")] Gacha gacha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gacha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gacha);
        }

        // GET: Admin/Gachas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gacha = await _context.Gachas.FindAsync(id);
            if (gacha == null)
            {
                return NotFound();
            }
            return View(gacha);
        }

        // POST: Admin/Gachas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GachaItems,GachaItemPercentages,ImageUrl,Description")] Gacha gacha)
        {
            if (id != gacha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gacha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GachaExists(gacha.Id))
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
            return View(gacha);
        }

        // GET: Admin/Gachas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gacha = await _context.Gachas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gacha == null)
            {
                return NotFound();
            }

            return View(gacha);
        }

        // POST: Admin/Gachas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gacha = await _context.Gachas.FindAsync(id);
            if (gacha != null)
            {
                _context.Gachas.Remove(gacha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GachaExists(int id)
        {
            return _context.Gachas.Any(e => e.Id == id);
        }
    }
}
