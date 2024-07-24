using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {//Dependecy Injection
            _manager = manager;
        }

        public IActionResult Index()
        {
            /* var context=new RepositoryContext(
              new DbContextOptionsBuilder<RepositoryContext>()
              .UseSqlite("Data Source =C:\\Users\\Casper\\OneDrive\\Masaüstü\\MVC\\ProductDb.db")
              .Options);*/
            var model = _manager.Product.GetAllProduct(false);
            return View(model);
        }
        public IActionResult Get(int id)
        {
            // Product product=_manager.Products.First(p =>p.ProductId.Equals(id));
            var model = _manager.Product.GetOneProduct(id, false);
            return View(model);
        }
    }
}