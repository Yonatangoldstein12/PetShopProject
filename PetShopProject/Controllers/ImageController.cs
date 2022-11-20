using Microsoft.AspNetCore.Mvc;

namespace PetShopProject.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
