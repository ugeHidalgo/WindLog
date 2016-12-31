using Microsoft.AspNetCore.Mvc;
using Microsoft.Framework.Configuration;
using System.Linq;
using WindLog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WindLog.Controllers.Web
{
    public class AppController : Controller
    {
        private IWindlogRepository _repository;
        private IConfigurationRoot _config;

        public AppController(IConfigurationRoot config, IWindlogRepository repository )
        {
            _config = config;
            _repository = repository;
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
            var data = _repository.GetAllSessions();
            return View(data);
        }

        public IActionResult Spots()
        {
            var data = _repository.GetAllSpots();
            return View(data);
        }

        public IActionResult Materials()
        {
            var data = _repository.GetAllMaterials();
            return View(data);
        }

        public IActionResult MaterialTypes()
        {
            var data = _repository.GetAllMaterialTypes();
            return View(data);
        }
    }
}
