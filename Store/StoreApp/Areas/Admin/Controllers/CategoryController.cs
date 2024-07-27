using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]//Taghelper
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}