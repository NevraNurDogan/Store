using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System.Reflection;
namespace Repositories
{

    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }//tablo oluşturuyor
        public DbSet<Category> Categories { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            //: base(options) ifadesi, RepositoryContext sınıfının yapıcı metodunun,
            // temel sınıf olan DbContext sınıfının yapıcı metodunu çağırmasını sağlar.

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.ApplyConfiguration(new ProductConfig());
         //   modelBuilder.ApplyConfiguration(new CategoryConfig());
         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}

