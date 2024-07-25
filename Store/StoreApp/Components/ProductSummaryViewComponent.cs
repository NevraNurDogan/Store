using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent :ViewComponent{//veritabanındaki ürün sayısını alabiliyorum.
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var count = _manager.ProductService.GetAllProducts(false).Count();
            return Content(count.ToString());
        }
    }
}