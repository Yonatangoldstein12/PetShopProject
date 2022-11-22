using Microsoft.AspNetCore.Mvc;
using PetShopProject.Models;
using PetShopProject.Repositories;
using PetShopProject.Services;

namespace PetShopProject.Controllers
{
    public class CatalogController : Controller
    {
        private Iripository iripository;
        private DBContext DB;
        public CatalogController(Iripository _iripository)
        {
            this.iripository = _iripository;
        }
        public IActionResult Index(int Id)
        {
            ViewBag.Categories= iripository.GetCategories();
            if (Id==0)
            return View(iripository.GetAnimals());
            else
            {
                return View(iripository.ByCategory(Id));
            }
        }
        public IActionResult Details(int Id)
        {
            ViewBag.comments = iripository.ShowComments(Id);
            var animals = iripository.GetAnimalById(Id);
            return View(animals);
        }
        [HttpPost]
        public IActionResult AddComment(int AnimalId,string comment)
        {
            var animals = iripository.GetAnimalById(AnimalId);
            iripository.AddComments(comment, AnimalId);
            return RedirectToAction("Index", "Catalog", new { id = AnimalId });
        }
    }
}
