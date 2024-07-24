using Entities.Models;
using Entities; 
using Repositories.Contracts;
namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository{
        public ProductRepository(RepositoryContext context) : base(context) { 


        }
     public IQueryable<Product> GetAllProduct(bool trackCahanges)=>FindAll(trackCahanges);

    }
}