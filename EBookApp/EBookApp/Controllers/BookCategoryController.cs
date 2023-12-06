using Microsoft.AspNetCore.Mvc;

namespace EBookApp.Controllers
{
	public class BookCategoryController : Controller
	{
        public IActionResult Roman()
        {
            return View();
        }

        public IActionResult Tarih()
        {
            return View();
        }

        public IActionResult BilimKurgu()
        {
            return View();
        }

        public IActionResult KisiselGelisim()
        {
            return View();
        }

        public IActionResult CizgiRoman()
        {
            return View();
        }

        public IActionResult Hikaye()
        {
            return View();
        }

        public IActionResult Ani()
        {
            return View();
        }
    }
}
