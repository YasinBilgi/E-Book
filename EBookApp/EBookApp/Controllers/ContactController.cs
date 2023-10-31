using EBook.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookApp.Controllers
{
    public class ContactController : Controller
    {
        EBookDbContext context = new EBookDbContext();

        public IActionResult Index()
        {
            return View();
        }
    }
}
