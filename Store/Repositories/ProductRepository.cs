using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository{
        public ProductRepository(RepositoryContext context) : base(context) { }
        /*Product türündeki tüm kayıtları sorgulamak için kullanılabilir bir sorgu oluşturur. */
        public IQueryable<Product> GetAllProducts(bool trackChanges)=>FindAll(trackChanges);
        /*GetOneProduct(int id, bool trackChanges): Bu, bir Product nesnesini almak için kullanılan 
        bir metodun tanımıdır. */
        public Product? GetOneProduct(int id,bool trackChanges){
        return FindByCondition(p=> p.ProductId.Equals(id), trackChanges );
    }
        /*CreateOneProduct(Product product): Bu, bir ürün oluşturmak için kullanılan bir metod tanımıdır. 
        Metod, bir Product nesnesi alır.
        => Create(product);: Bu ifade, Create metodunu çağırarak verilen product nesnesini veri tabanına ekler.*/
        public void CreateOneProduct(Product product) => Create(product);
        /*DeleteOneProduct(Product product): Bu metod, bir Product nesnesini silmek için kullanılır. 
        Parametre olarak bir Product nesnesi alır.
        => Remove(product);: Bu ifade, Remove metodunu çağırarak verilen product nesnesini veri tabanından siler.*/
        public void DeleteOneProduct(Product product) => Remove(product);

        public void UpdateOneProduct(Product entity) => Update(entity);
    }
}