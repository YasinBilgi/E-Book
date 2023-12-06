using Microsoft.AspNetCore.Mvc;

namespace EBookApp.Controllers
{
    public class BookController : Controller
    {
        public IActionResult SavasVeBaris()
        {
            return View();
        }
    }
}
