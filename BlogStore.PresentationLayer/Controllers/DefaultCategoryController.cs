using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class DefaultCategoryController : Controller
    {
        public IActionResult Index(int id)
        {
            ViewBag.i = id;
            return View();
        }
    }
}
