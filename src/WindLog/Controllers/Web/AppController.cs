using Microsoft.AspNetCore.Mvc;
using WindLog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WindLog.Controllers.Web
{
    public class AppController : Controller
    {
        private WindlogContext _context;

        public AppController(WindlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
