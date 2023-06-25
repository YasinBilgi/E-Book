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
    public class AuthorsController : Controller
    {
        private readonly EBookDbContext _context = new EBookDbContext();

        private readonly IWebHostEnvironment _hostEnvironment;

        public AuthorsController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
       
        // GET: ManagementPanel/Authors
        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                          View(await _context.Authors.ToListAsync()) :
                          Problem("Entity set 'EBookDbContext.Authors'  is null.");
        }

        // GET: ManagementPanel/Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: ManagementPanel/Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    author.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                }
                author.Status = true;
                author.CreatedDate = DateTime.Now;

                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: ManagementPanel/Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(r => r.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: ManagementPanel/Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author, IFormFile img)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    Author editAuthor = await _context.Authors.FirstOrDefaultAsync(r => r.Id == author.Id);
                    if (img != null)
                    {
                        editAuthor.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                    }

                    editAuthor.FirstName = author.FirstName;
                    editAuthor.LastName = author.LastName;
                    editAuthor.BirthDate = author.BirthDate;
                    editAuthor.DeathDate = author.DeathDate;
                    editAuthor.Biography = author.Biography;
                    editAuthor.İmageUrl = author.İmageUrl;
                    editAuthor.Status = author.Status;
                    editAuthor.CreatedDate = author.CreatedDate;

                    _context.Update(author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: ManagementPanel/Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: ManagementPanel/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'EBookDbContext.Authors'  is null.");
            }
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
          return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
