
using Entities.Models;
namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackCahanges);

        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product entity);
    }

}