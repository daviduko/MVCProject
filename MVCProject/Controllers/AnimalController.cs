using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Hosting;
using MVCProject.DAL;
using MVCProject.Models;
using MVCProject.Models.ViewModels;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVCProject.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Insert()
        {
            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();
            var tiposDeAnimal = tipoAnimalDAL.GetAll();

            ViewBag.TiposDeAnimal = tiposDeAnimal.Select(t => new SelectListItem
            {
                Value = t.IdTipoAnimal.ToString(),
                Text = t.TipoDescripcion
            });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(InsertAnimalViewModel model)
        {
            if (ModelState.IsValid)
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

                TempData["Success"] = "Se ha creado el animal";

                return RedirectToAction("Index", "Home");
            }

            TipoAnimalDAL tipoAnimalDAL = new TipoAnimalDAL();
            var tiposDeAnimal = tipoAnimalDAL.GetAll();

            ViewBag.TiposDeAnimal = tiposDeAnimal.Select(t => new SelectListItem
            {
                Value = t.IdTipoAnimal.ToString(),
                Text = t.TipoDescripcion
            });

            ViewBag.Error = "No se ha podido crear el animal";

            return View(model);
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
        public IActionResult Details()
        {
            if (TempData["Animal"] != null)
            {
                var json = TempData["Animal"] as string;
                var viewModel = JsonConvert.DeserializeObject<DetailAnimalViewModel>(json);

                return View(viewModel);
            }

            ViewBag.NoAnimal = "No se ha encontrado ningún animal";
            return View();
        }
    }
}
