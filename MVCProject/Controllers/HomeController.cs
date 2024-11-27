using Microsoft.AspNetCore.Mvc;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.Models.ViewModels;
using Newtonsoft.Json;
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
            AnimalDAL dal = new AnimalDAL();

            AnimalViewModel viewModel = new AnimalViewModel();
            viewModel.Animales = dal.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AnimalDetail(int id)
        {
            //return RedirectToAction("Details", "Animal", new { id });

            AnimalDAL dal = new AnimalDAL();
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

            DetailAnimalViewModel viewModel = new DetailAnimalViewModel();

            viewModel.AnimalDetail = dal.GetById(id);
            viewModel.TiposDeAnimal = tipoAnimalDAL.GetAll();

            TempData["Animal"] = JsonConvert.SerializeObject(viewModel);

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
