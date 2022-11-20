using Microsoft.AspNetCore.Mvc;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers
{
    public class HomeController : Controller
    {
        private Iripository iripository;
        public HomeController(Iripository iripository)
        {
            this.iripository = iripository;
        }
       
        public IActionResult Index()
        {
            return View(iripository.Top2Animal());
        }

    }
}
