using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    //Bu sınıf, genel CRUD (Create, Read, Update, Delete) 
    //işlemlerini sağlamak için bir temel sınıf olarak kullanılır.
    public class RepositoryBase<T> : IRepositoryBase<T>
    
        where T : class, new()
        /*  where T : class = > Bu, Tnin bir sınıf, interface, array,
         delegate, veya string gibi bir referans tipi olması gerektiği anlamına gelir.
         where T : new() = > Bu kısıtlama ise, T türünün bir parametresiz yapıcı metoda 
         (constructor) sahip olması gerektiğini belirtir. Bu sayede, RepositoryBase 
         sınıfı içinde new T() gibi bir kullanım yapılabilir.*/
    {
        protected readonly RepositoryContext _context;// sadece base classta değil devraldığım classlarda da kullanmak istiyorum. 
                                                      //bu yüzden protected

        protected RepositoryBase(RepositoryContext context)
        {//veritabanın erişim sağlayabiliyorum
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {//Bu parametre, veri izleme durumunu kontrol eder.
            return trackChanges
            ? _context.Set<T>()
            : _context.Set<T>().AsNoTracking();
            /*
         FindAll metodunda trackChanges parametresi, 
        veri izleme durumunu kontrol eder:
        Eğer trackChanges true ise, Set<T>() kullanılarak izleme yapılır.
        Eğer trackChanges false ise, AsNoTracking() kullanılarak izleme yapılmaz.
        Bu yapı, performans optimizasyonu ve işlem gereksinimlerine göre esneklik sağlar.*/
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
           ? _context.Set<T>().Where(expression).SingleOrDefault()//bir kayıt döndürmesini sağlar
           : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
}
