using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        /*protected: Bu alan sadece bu sınıf içinde ve bu sınıftan türeyen sınıflarda erişilebilir.
        readonly: Bu alanın değeri yalnızca sınıfın yapıcı metodunda atanabilir ve daha sonra değiştirilemez.
        RepositoryContext _context: Bu, veritabanı bağlamını temsil eden bir alan. Veritabanı işlemleri bu bağlam aracılığıyla yapılır.*/
        protected readonly RepositoryContext _context;
        /*IProductRepository _productRepository: Ürün repository'sini temsil eden bir alan. 
        Ürünlerle ilgili veritabanı işlemleri bu repository üzerinden yapılır.*/
       private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public RepositoryManager(IProductRepository productRepository,
        RepositoryContext context,
        ICategoryRepository categoryRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IProductRepository Product => _productRepository;
        /*Bu ifade, Product adında bir property tanımlar ve bu property'nin değeri _productRepository alanına (field) bağlıdır.
        Product property’si IProductRepository türündedir.
        => (lambda operatörü) burada expression-bodied (ifadeye dayalı) property tanımı yapar ve bu sayede Product property’si sadece _productRepository alanının değerini döndürür.
        Product property’si sadece get işlemi yapar, yani dışarıdan bu property’ye bir değer atanamaz, sadece okunabilir.*/

        public ICategoryRepository Category => _categoryRepository;
        /*Bu tanımlar, RepositoryManager sınıfı içinde IProductRepository ve ICategoryRepository türündeki özel alanların (fields)
         dışarıya güvenli bir şekilde sunulmasını sağlar. Bu sayede, dışarıdaki kod bu repository'lere erişebilir ve işlem yapabilir,
          ancak bu repository örneklerini değiştiremez.*/
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}