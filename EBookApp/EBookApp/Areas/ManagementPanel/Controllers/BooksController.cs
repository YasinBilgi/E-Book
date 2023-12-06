using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EBook.Entities.Models;
using EBookApp.Areas.ManagementPanel.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EBookApp.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class BooksController : Controller
    {
        private readonly EBookDbContext context = new EBookDbContext();

        private readonly IWebHostEnvironment _hostEnvironment;

        public BooksController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        // GET: ManagementPanel/Books
        public async Task<IActionResult> Index()
        {
            var eBookDbContext = context.Books.Include(b => b.Library).Include(b => b.User);
            return View(await eBookDbContext.ToListAsync());
        }

        // GET: ManagementPanel/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Books == null)
            {
                return NotFound();
            }

            var book = await context.Books
                .Include(b => b.Library)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: ManagementPanel/Books/Create
        public IActionResult Create()
        {
            ViewData["LibraryId"] = new SelectList(context.Libraries, "Id", "LibraryName");
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Email");
            return View();
        }

        // POST: ManagementPanel/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    book.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                }
                book.Status = true;
                book.CreatedDate = DateTime.Now;

                context.Books.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibraryId"] = new SelectList(context.Libraries, "Id", "LibraryName", book.LibraryId);
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Email", book.UserId);
            return View(book);
        }

        // GET: ManagementPanel/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Books == null)
            {
                return NotFound();
            }

            var book = await context.Books.Include(x => x.BookDetail).FirstOrDefaultAsync(r => r.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["LibraryId"] = new SelectList(context.Libraries, "Id", "LibraryName", book.LibraryId);
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Email", book.UserId);
            return View(book);
        }

        // POST: ManagementPanel/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Book editBook = await context.Books.Include(x => x.BookDetail).FirstOrDefaultAsync(r => r.Id == book.Id);
                    if (img != null)
                    {
                        editBook.İmageUrl = await İmageUpload.UploadImageAsync(_hostEnvironment, img);
                    }

                    editBook.Name = book.Name;
                    editBook.AuthorName = book.AuthorName;
                    editBook.NumberPage = book.NumberPage;
                    editBook.PublishDate = book.PublishDate;
                    editBook.Isbn = book.Isbn;
                    editBook.Status = book.Status;
                    editBook.Description = book.Description;

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibraryId"] = new SelectList(context.Libraries, "Id", "LibraryName", book.LibraryId);
            ViewData["UserId"] = new SelectList(context.Users, "Id", "Email", book.UserId);
            return View(book);
        }

        // GET: ManagementPanel/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Books == null)
            {
                return NotFound();
            }

            var book = await context.Books
                .Include(b => b.Library)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: ManagementPanel/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Books == null)
            {
                return Problem("Entity set 'EBookDbContext.Books'  is null.");
            }
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
            }
            
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
