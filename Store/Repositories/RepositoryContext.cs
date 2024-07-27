using Microsoft.EntityFrameworkCore;
using Entities.Models;
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
            modelBuilder.Entity<Product>()
            .HasData(
                new Product() { ProductId = 1, CategoryId=2,ProductName = "Computer", Price = 17_000 },
                new Product() { ProductId = 2, CategoryId=2,ProductName = "Keyboard", Price = 1_000 },
                new Product() { ProductId = 3, CategoryId=2,ProductName = "Mouse", Price = 500 },
                new Product() { ProductId = 4, CategoryId=2,ProductName = "Monitor", Price = 7_000 },
                new Product() { ProductId = 5, CategoryId=2,ProductName = "Deck", Price = 1_500 },
                new Product() { ProductId = 6, CategoryId=1,ProductName = "History", Price = 225 },
                new Product() { ProductId = 7, CategoryId=1,ProductName = "Hamlet", Price = 45 }

            );
            modelBuilder.Entity<Category>()
            .HasData(
                new Category() { CategoryId = 1, CategoryName = "Books" },
                new Category() { CategoryId = 2, CategoryName = "Electronic" }
            );
        }
    }
}

