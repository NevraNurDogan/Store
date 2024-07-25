using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {//Dependecy Injection
            _manager = manager;
        }

        public IActionResult Index()
        {
            /* var context=new RepositoryContext(
              new DbContextOptionsBuilder<RepositoryContext>()
              .UseSqlite("Data Source =C:\\Users\\Casper\\OneDrive\\Masaüstü\\MVC\\ProductDb.db")
              .Options);*/
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Get([FromRoute(Name="id")] int id)
        {
            // Product product=_manager.Products.First(p =>p.ProductId.Equals(id));
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}