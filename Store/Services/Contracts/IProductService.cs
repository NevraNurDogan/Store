using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        //okuma işlemleri
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);//ürün getirebilecek



    }
}