using Microsoft.AspNetCore.Mvc;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.Models.ViewModels;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AnimalViewModel viewModel = new AnimalViewModel();
            return View(viewModel);
        }

        public IActionResult AnimalDetail(int id)
        {
            //AnimalDAL dal = new AnimalDAL();
            //DetailAnimalViewModel vm = new DetailAnimalViewModel();

            //vm.AnimalDetail = dal.GetById(id);

            //TempData["Animal"] = JsonConvert.SerializeObject(vm);

            return RedirectToAction("Details", "Animal");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
