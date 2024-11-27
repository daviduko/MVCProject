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
            InsertAnimalViewModel viewModel = new InsertAnimalViewModel();
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

            viewModel.TiposDeAnimal = tipoAnimalDAL.GetAll();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(InsertAnimalViewModel model)
        {
            AnimalDAL animalDAL = new AnimalDAL();
            animalDAL.Insert
            (
                new Animal
                {
                    NombreAnimal = model.NombreAnimal,
                    Raza = model.Raza,
                    RIdTipoAnimal = model.RIdTipoAnimal,
                    FechaNacimiento = model.FechaNacimiento
                }
            );

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(int idAnimal, string nombreAnimal, string raza, int tipoDeAnimalId, DateTime? fechaNacimiento)
        {
            AnimalDAL animalDAL = new AnimalDAL();
            animalDAL.Update
            (
                new Animal
                {
                    IdAnimal = idAnimal,
                    NombreAnimal = nombreAnimal,
                    Raza = raza,
                    RIdTipoAnimal = tipoDeAnimalId,
                    FechaNacimiento = fechaNacimiento
                }
            );

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Delete(int idAnimal)
        {
            AnimalDAL animalDAL = new AnimalDAL();
            animalDAL.Delete(idAnimal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            AnimalDAL dal = new AnimalDAL();
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();

            DetailAnimalViewModel viewModel = new DetailAnimalViewModel();

            viewModel.AnimalDetail = dal.GetById(id);
            viewModel.TiposDeAnimal = tipoAnimalDAL.GetAll();

            if (viewModel.AnimalDetail == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}
