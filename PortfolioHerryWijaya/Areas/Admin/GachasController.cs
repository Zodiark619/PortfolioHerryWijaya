using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioHerryWijaya.Data;
using PortfolioHerryWijaya.Models.Domain.Portfolio3;
using PortfolioHerryWijaya.Models.ViewModels;

namespace PortfolioHerryWijaya.Areas.Admin
{
    [Area("Admin")]
    [Authorize]

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
            ViewBag.GachaItems=_context.GachaItems.ToList();
            return View();
        }

        // POST: Admin/Gachas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GachaItems,GachaItemPercentages,ImageUrl,Description")] Gacha gacha
       // public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl,Description")] Gacha gacha
            ,IFormFile? ImageFile
            ,string item1, string item2, string item3, string item4, string item5
            , int itempercentage1, int itempercentage2, int itempercentage3, int itempercentage4, int itempercentage5)
        {
            ViewBag.GachaItems = _context.GachaItems.ToList();
          //  ModelState["GachaItems"].ValidationState.
           // ModelState["GachaItemPercentages"].ValidationState.
            if (ModelState.IsValid)
            {

                if (ImageFile != null)
                {
                   // gacha.ImageUrl =ImageFile.FileName+  System.IO.Path.GetExtension(ImageFile.FileName);
                    gacha.ImageUrl =ImageFile.FileName;
                    string fn;
                    fn = Directory.GetCurrentDirectory();
                    string ImagePath = Path.Combine(fn + "\\wwwroot\\phantom\\project3\\" + gacha.ImageUrl);

                    using (var stream = new FileStream(ImagePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }
                }
                gacha.GachaItemPercentages = new int[5] ;
                gacha.GachaItems = new string[5] ;
                gacha.GachaItems[0] = item1;
                gacha.GachaItems[1] = item2;
                gacha.GachaItems[2] = item3;
                gacha.GachaItems[3] = item4;
                gacha.GachaItems[4] = item5;

                gacha.GachaItemPercentages[0] = itempercentage1;
                gacha.GachaItemPercentages[1] = itempercentage2;
                gacha.GachaItemPercentages[2] = itempercentage3;
                gacha.GachaItemPercentages[3] = itempercentage4;
                gacha.GachaItemPercentages[4] = itempercentage5;

                _context.Add(gacha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gacha);
        }

        // GET: Admin/Gachas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.GachaItems = _context.GachaItems.ToList();
           
            if (id == null)
            {
                return NotFound();
            }

            var gacha = await _context.Gachas.FindAsync(id);
            if (gacha == null)
            {
                return NotFound();
            }
            //Project3EditViewModel model = new Project3EditViewModel();
            //model.Id=gacha.Id;
            //model.Name=gacha.Name;
            //model.Description=gacha.Description;
            //model.ImageUrl=gacha.ImageUrl;
            //model.GachaItemPercentages[0]=gacha.GachaItemPercentages[0];
            //model.GachaItemPercentages[1]=gacha.GachaItemPercentages[1];
            //model.GachaItemPercentages[2]=gacha.GachaItemPercentages[2];
            //model.GachaItemPercentages[3]=gacha.GachaItemPercentages[3];
            //model.GachaItemPercentages[4]=gacha.GachaItemPercentages[4];

            //model.GachaItems[0] = gacha.GachaItems[0];
            
            return View(gacha);
        }

        // POST: Admin/Gachas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GachaItems,GachaItemPercentages,ImageUrl,Description")] Gacha gacha
          
            , IFormFile? ImageFile
            , string item1, string item2, string item3, string item4, string item5
            , int itempercentage1, int itempercentage2, int itempercentage3, int itempercentage4, int itempercentage5
            )
        {
            ViewBag.GachaItems = _context.GachaItems.ToList();

            if (id != gacha.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ImageFile != null)
                    {
                        //-----------------
                        string org_fn;
                        org_fn = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/phantom/project3/" + gacha.ImageUrl);

                        if (System.IO.File.Exists(org_fn))
                        {
                            System.IO.File.Delete(org_fn);
                        }
                        //-----------------
                      //  gacha.ImageUrl = ImageFile.FileName + Path.GetExtension(ImageFile.FileName);
                        gacha.ImageUrl = ImageFile.FileName ;
                        //-----------------
                        string ImagePath;
                        ImagePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\phantom\\project3\\" + gacha.ImageUrl);

                        using (var stream = new FileStream(ImagePath, FileMode.Create))
                        {
                            ImageFile.CopyTo(stream);
                        }

                    }
                    gacha.GachaItemPercentages = new int[5];
                    gacha.GachaItems = new string[5];
                    gacha.GachaItems[0] = item1;
                    gacha.GachaItems[1] = item2;
                    gacha.GachaItems[2] = item3;
                    gacha.GachaItems[3] = item4;
                    gacha.GachaItems[4] = item5;

                    gacha.GachaItemPercentages[0] = itempercentage1;
                    gacha.GachaItemPercentages[1] = itempercentage2;
                    gacha.GachaItemPercentages[2] = itempercentage3;
                    gacha.GachaItemPercentages[3] = itempercentage4;
                    gacha.GachaItemPercentages[4] = itempercentage5;
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
