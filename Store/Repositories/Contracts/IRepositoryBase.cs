using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        /* Veritabanına sorgu gönderme imkanı sağlayan bir arayüzdür. 
        LINQ sorgularının veritabanına nasıl çevrileceğini ve bu sorguların
         nasıl çalıştırılacağını belirtir. Veri tabanı üzerinde sorgu oluşturmaya
         ve sorgunun veritabanında çalıştırılacağı ana kadar bu sorguyu inşa etmeye olanak tanır.
         IQueryable kullanmanın en büyük avantajı, performanslı sorgular yazılmasını sağlamasıdır.
         trackChanges (bool): Bu parametre, sorgunun nesne izleme (tracking) ile mi yoksa izleme 
         olmadan mı yapılacağını belirler. İzleme açıkken, veritabanından dönen nesnelerde yapılan 
         değişiklikler otomatik olarak izlenir ve SaveChanges() çağrıldığında veritabanına yansıtılır.
         bu metod, sadece temel bir "tüm kayıtları getir" sorgusu oluşturur. IQueryable<T> döndürdüğü için, 
         bu sorgu üzerinde daha fazla filtreleme, sıralama ve projeleme işlemleri yapılabilir.*/
        IQueryable<T> FindAll(bool trackChanges);
        /*Bu metod, belirli bir koşulu sağlayan tek bir kaydı döndürür.
        T?: T bir sınıf (class) türüdür ve bu metod, T tipinde bir nesne döndürebilir 
        ya da null dönebilir (o yüzden T? şeklinde belirtilmiştir). Bu da metodun, ilgili koşulu sağlayan 
        bir kayıt bulamazsa null döneceği anlamına gelir.
        Expression<Func<T, bool>> expression: Bu, LINQ sorgularında kullanılan bir ifade ağacı (expression tree)
         tanımlamaktır. Bu parametre, bir lambda ifadesi olarak verilen koşulu temsil eder ve bu koşula uyan kayıtları arar. 
         Örneğin, x => x.Id == 5 gibi bir ifade, belirli bir ID'ye sahip olan kaydı bulmak için kullanılabilir.*/
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        /*T entity: T tipinde bir nesne alır ve bu nesneyi veritabanına ekler.*/
        void Create(T entity);
        /*T entity: T tipinde bir nesne alır ve bu nesneyi veritabanından siler.*/
        void Remove(T entity);
        void Update(T entity);  
    }
}