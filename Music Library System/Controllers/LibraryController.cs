using Microsoft.AspNetCore.Mvc;

namespace Music_Library_System.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
