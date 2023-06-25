using Microsoft.AspNetCore.Mvc;

namespace EBookApp.Areas.ManagementPanel.Controllers
{
    [Area("ManagementPanel")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
