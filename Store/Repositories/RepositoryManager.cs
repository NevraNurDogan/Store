using Repositories.Contracts;

namespace Repositories{
    public class RepositoryManager: IRepositoryManager{
        protected readonly RepositoryContext _context;// sadece base classta değil devraldığım classlarda da kullanmak istiyorum. bu yüzden protected

        private readonly IProductRepository _productRepository;
        public RepositoryManager(IProductRepository productRepository){
            _productRepository = productRepository;
            _context=  _context;
        }
       public IProductRepository Product=>_productRepository;      
        public void Save(){
        _context.SaveChanges();
       }
    }
}