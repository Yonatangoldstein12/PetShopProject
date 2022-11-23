using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetShopProject.Models;
using PetShopProject.Repositories;
using PetShopProject.Services;
using System.Xml.Linq;

namespace PetShopProject.Controllers
{
    public class CatalogController : Controller
    {
        private Iripository iripository;
       
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

            var comments = iripository.ShowComments(Id);
            var animals = iripository.GetAnimalById(Id);
            return View(animals);
        }
        [HttpPost]
        public IActionResult AddComment(int AnimalId,string comment)
        {
            if (comment.IsNullOrEmpty()||comment.Length>100)
            {

                return RedirectToAction("Details", "Catalog", new { id = AnimalId });
            }
            else
            {
            var animals = iripository.GetAnimalById(AnimalId);
            iripository.AddComments(comment, AnimalId);
            }
            return RedirectToAction("Details", "Catalog", new { id = AnimalId });
        }
    }
}
