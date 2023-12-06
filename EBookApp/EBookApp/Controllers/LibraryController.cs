using EBook.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookApp.Controllers
{
    public class LibraryController : Controller
    {
        EBookDbContext context = new EBookDbContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(Library library)
        {
            return View();
        }
    }
}
