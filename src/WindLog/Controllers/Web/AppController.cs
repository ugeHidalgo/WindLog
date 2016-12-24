using Microsoft.AspNetCore.Mvc;
using Microsoft.Framework.Configuration;
using System.Linq;
using WindLog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WindLog.Controllers.Web
{
    public class AppController : Controller
    {
        private WindlogContext _context;
        private IConfigurationRoot _config;

        public AppController(IConfigurationRoot config, WindlogContext context)
        {
            _config = config;
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

        public IActionResult Sessions()
        {
            var data = _context.Sessions.ToList();
            return View(data);
        }

        public IActionResult Spots()
        {
            return View();
        }

        public IActionResult Materials()
        {
            return View();
        }

        public IActionResult MaterialTypes()
        {
            return View();
        }
    }
}
