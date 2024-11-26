using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.Models.ViewModels;
using System.Diagnostics;

namespace MVCProject.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            AnimalViewModel viewModel = new AnimalViewModel();
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

            viewModel.TiposDeAnimal = tipoAnimalDAL.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Insert(string nombreAnimal, string raza, int tipoDeAnimalId, DateTime fechaNacimiento)
        {
            AnimalDAL animalDAL = new AnimalDAL();
            animalDAL.Insert
            (
                new Animal
                {
                    NombreAnimal = nombreAnimal,
                    Raza = raza,
                    RIdTipoAnimal = tipoDeAnimalId,
                    FechaNacimiento = fechaNacimiento
                }
            );

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel viewModel = new DetailAnimalViewModel();

            viewModel.AnimalDetail = dal.GetById(id);

            if (viewModel.AnimalDetail == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}
