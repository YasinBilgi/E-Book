using EBook.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookApp.Controllers
{
    public class ContactController : Controller
    {
        EBookDbContext context = new EBookDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            if(User == null)
            {
              
            }
            return View(contact);
        }
    }
}
