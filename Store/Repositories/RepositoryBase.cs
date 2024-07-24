using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T: class,new(){
            protected readonly RepositoryContext _context;// sadece base classta değil devraldığım classlarda da kullanmak istiyorum. bu yüzden protected

            protected RepositoryBase(RepositoryContext context){//veritabanın aerişim sağlayabiliyorum
                _context = context; 
            }

        public IQueryable<T> FindAll(bool trackCahanges){//Bu parametre, veri izleme durumunu kontrol eder.
                return trackCahanges
                ? _context.Set<T>()
                :_context.Set<T>().AsNoTracking();
                /*
             FindAll metodunda trackChanges parametresi, 
                veri izleme durumunu kontrol eder:
            Eğer trackChanges true ise, Set<T>() kullanılarak izleme yapılır.
            Eğer trackChanges false ise, AsNoTracking() kullanılarak izleme yapılmaz.
            Bu yapı, performans optimizasyonu ve işlem gereksinimlerine göre esneklik sağlar.*/
             }

        }
    }
