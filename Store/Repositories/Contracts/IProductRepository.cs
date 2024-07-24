using Entities; 
using Entities.Models;
namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>{
        IQueryable<Product> GetAllProduct(bool trackCahanges);
        IQueryable<Product> FindAll(bool trackCahanges);
    }

}