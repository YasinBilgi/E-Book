using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBook.Entities.Models;

namespace EBookApp.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class MainPagesController : Controller
    {
        private readonly EBookDbContext _context= new EBookDbContext();

        // GET: ManagementPanel/MainPages
        public async Task<IActionResult> Index()
        {
              return _context.MainPages != null ? 
                          View(await _context.MainPages.ToListAsync()) :
                          Problem("Entity set 'EBookDbContext.MainPages'  is null.");
        }

        // GET: ManagementPanel/MainPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MainPages == null)
            {
                return NotFound();
            }

            var mainPage = await _context.MainPages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainPage == null)
            {
                return NotFound();
            }

            return View(mainPage);
        }

        // GET: ManagementPanel/MainPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/MainPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MainPage mainPage)
        {
            if (ModelState.IsValid)
            {
                mainPage.Status = true;
                mainPage.CreatedDate = DateTime.Now;

                _context.MainPages.Add(mainPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainPage);
        }

        // GET: ManagementPanel/MainPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MainPages == null)
            {
                return NotFound();
            }

            var mainPage = await _context.MainPages.FindAsync(id);
            if (mainPage == null)
            {
                return NotFound();
            }
            return View(mainPage);
        }

        // POST: ManagementPanel/MainPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MainPage mainPage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MainPage EditMainPage = await _context.MainPages.FindAsync(mainPage.Id);
                    
                    EditMainPage.Title = mainPage.Title;
                    EditMainPage.Description = mainPage.Description;
                    EditMainPage.Status = mainPage.Status;
                    EditMainPage.CreatedDate = mainPage.CreatedDate;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mainPage);
        }

        // GET: ManagementPanel/MainPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MainPages == null)
            {
                return NotFound();
            }

            var mainPage = await _context.MainPages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainPage == null)
            {
                return NotFound();
            }

            return View(mainPage);
        }

        // POST: ManagementPanel/MainPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MainPages == null)
            {
                return Problem("Entity set 'EBookDbContext.MainPages'  is null.");
            }
            var mainPage = await _context.MainPages.FindAsync(id);
            if (mainPage != null)
            {
                _context.MainPages.Remove(mainPage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainPageExists(int id)
        {
          return (_context.MainPages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
