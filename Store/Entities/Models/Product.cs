using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product Name id required.")]
    public String? ProductName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Price id required.")]

    public decimal Price { get; set; }
}
