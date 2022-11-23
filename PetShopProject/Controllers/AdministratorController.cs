using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PetShopProject.Models;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers
{
    public class AdministratorController : Controller
    {
        private Iripository iripository;
            private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _HostDataBase;

        public AdministratorController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _HostingContext,Iripository _iripository)
        {
            this.iripository= _iripository;
            this._HostDataBase = _HostingContext;

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
            string UniqeFileName = null;
            if(
                ModelState.ErrorCount == 1 &&
                ModelState.GetFieldValidationState("PicturePath") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                string UploadFolder = Path.Combine(_HostDataBase.WebRootPath, "Images");
                UniqeFileName = Guid.NewGuid().ToString() + "_" + animal.File!.FileName;
                string FilePath = Path.Combine(UploadFolder, UniqeFileName);
                animal.File.CopyTo(new FileStream(FilePath, FileMode.Create));
            }
            Animal NewAnimal = new Animal
            {
                Name = animal.Name,
                Age = animal.Age,
                CategoryId = animal.CategoryId,
                Descripition = animal.Descripition,
                PicturePath = "Images\\" + UniqeFileName
            };

            iripository.UpdateAnimal(id, NewAnimal);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddAnimal()
        {
            ViewBag.Categories = iripository.GetCategories();
            return View(new Animal());
        }
        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
              string UniqeFileName = null;

            if (
                ModelState.ErrorCount==1&&
                ModelState.GetFieldValidationState("PicturePath")==Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                string UploadFolder = Path.Combine(_HostDataBase.WebRootPath, "Images");
                UniqeFileName = Guid.NewGuid().ToString() + "_" + animal.File!.FileName;
                string FilePath = Path.Combine(UploadFolder, UniqeFileName);
                animal.File.CopyTo(new FileStream(FilePath, FileMode.Create));
            }
            Animal NewAnimal = new Animal
            {
                Name = animal.Name,
                Age = animal.Age,
                CategoryId = animal.CategoryId,
                Descripition = animal.Descripition,
                PicturePath = "Images\\" + UniqeFileName
            };
            iripository.AddAnimal(NewAnimal);
            return RedirectToAction("Index", "Catalog");

            //iripository.AddAnimal(animal);
            //return RedirectToAction("Index", iripository.GetAnimals());
        }
    }
}
