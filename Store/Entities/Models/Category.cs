namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        //Collection navigation property
        public ICollection<Product> Products { get; set; }

    }
}