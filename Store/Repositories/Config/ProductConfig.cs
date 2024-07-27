using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            throw new NotImplementedException();
        }
    }
}