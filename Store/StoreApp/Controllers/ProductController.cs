using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Controllers{
    public class ProductController:Controller{
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context){//Dependecy Injection
            _context=context;
        }
    
    public IActionResult Index(){
          /* var context=new RepositoryContext(
            new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlite("Data Source =C:\\Users\\Casper\\OneDrive\\Masaüstü\\MVC\\ProductDb.db")
            .Options);*/
        var model=_context.Products.ToList();
        return View(model);
    }
     public IActionResult Get(int id){
        Product product=_context.Products.First(p =>p.ProductId.Equals(id));
        return View(product);

        }
    }
}