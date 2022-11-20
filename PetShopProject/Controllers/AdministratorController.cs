using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PetShopProject.Models;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers
{
    public class AdministratorController : Controller
    {
        private Iripository iripository;
      
        public AdministratorController(Iripository _iripository)
        {
            this.iripository= _iripository;
        }
        public IActionResult Index(int Id)
        {
            ViewBag.Categories = iripository.GetCategories();
            if (Id == 0)
                return View(iripository.GetAnimals());
            else
            {
                return View(iripository.ByCategory(Id));
            }
        }
       
        public IActionResult DeleteAnimal(int Id)
        {
            iripository.Delete(Id);
            return RedirectToAction("Index", iripository.GetAnimals());
        }
    
        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            ViewBag.Categories = iripository.GetCategories();
            return View(iripository.GetAnimalById(id));
        }
        [HttpPost]
        public IActionResult EditAnimal(int id, Animal animal)
        {
            iripository.UpdateAnimal(id, animal);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddAnimal()
        {
            ViewBag.Categories = iripository.GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            iripository.AddAnimal(animal);
            return RedirectToAction("Index", iripository.GetAnimals());
        }
    }
}
