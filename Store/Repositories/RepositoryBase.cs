using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class, new()
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

       
    }
}
