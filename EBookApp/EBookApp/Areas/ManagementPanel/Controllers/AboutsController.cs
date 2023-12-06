using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBook.Entities.Models;
using EBookApp.Areas.ManagementPanel.Helpers;

namespace EBookApp.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class AboutsController : Controller
    {
        private readonly EBookDbContext _context = new EBookDbContext();

        private readonly IWebHostEnvironment _hostEnvironment;

        public AboutsController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        // GET: ManagementPanel/Abouts
        public async Task<IActionResult> Index()
        {
              return _context.Abouts != null ? 
                          View(await _context.Abouts.ToListAsync()) :
                          Problem("Entity set 'EBookDbContext.Abouts'  is null.");
        }

        // GET: ManagementPanel/Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: ManagementPanel/Abouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    about.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                }
                about.Status = true;
                about.CreatedDate = DateTime.Now;

                _context.Abouts.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: ManagementPanel/Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.FirstOrDefaultAsync(r => r.Id == id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: ManagementPanel/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About about, IFormFile img)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    About editAbout = await _context.Abouts.FirstOrDefaultAsync(r => r.Id == about.Id);
                    if (img != null)
                    {
                        editAbout.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                    }

                    editAbout.Title = about.Title;
                    editAbout.Subtitle = about.Subtitle;
                    editAbout.Description = about.Description;
                    editAbout.Status = about.Status;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: ManagementPanel/Abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: ManagementPanel/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abouts == null)
            {
                return Problem("Entity set 'EBookDbContext.Abouts'  is null.");
            }
            var about = await _context.Abouts.FindAsync(id);
            if (about != null)
            {
                _context.Abouts.Remove(about);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
          return (_context.Abouts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
