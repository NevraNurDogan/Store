using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System.Reflection;
namespace Repositories
{

    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }//tablo oluşturuyor
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            //: base(options) ifadesi, RepositoryContext sınıfının yapıcı metodunun,
            // temel sınıf olan DbContext sınıfının yapıcı metodunu çağırmasını sağlar.

        }
        /*OnModelCreating metodu, Entity Framework Core'da model oluşturma sırasında konfigürasyonları 
        belirlemek için kullanılır. Bu metod, DbContext sınıfının bir parçasıdır ve veritabanı şeması üzerinde
         özelleştirmeler yapmanıza olanak tanır.*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.ApplyConfiguration(new ProductConfig());
         //   modelBuilder.ApplyConfiguration(new CategoryConfig());
         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         /*Alternatif olarak, ApplyConfigurationsFromAssembly metodu, belirli bir assembly'deki tüm konfigürasyonları 
         otomatik olarak uygular, bu da yapılandırma işlemlerini daha merkezi ve yönetilebilir hale getirir.*/


        }
    }
   
}

