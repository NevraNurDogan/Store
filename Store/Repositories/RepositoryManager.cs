using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        protected readonly RepositoryContext _context;// sadece base classta değil devraldığım classlarda da kullanmak istiyorum. bu yüzden protected
        private readonly IProductRepository _productRepository;
         private readonly ICategoryRepository _categoryRepository;
        public RepositoryManager(IProductRepository productRepository,
        RepositoryContext context,
        ICategoryRepository categoryRepository )
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}