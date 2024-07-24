
using Entities.Models;
namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProduct(bool trackCahanges);
        Product? GetOneProduct(int id, bool trackChanges);

    }

}