using Microsoft.AspNetCore.Mvc;
using MVCProject.DAL;
using MVCProject.Models.ViewModels;

namespace MVCProject.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
