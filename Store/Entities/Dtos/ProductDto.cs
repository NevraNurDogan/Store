using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }

        [Required(ErrorMessage = "Product Name id required.")]
        public String? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Price id required.")]

        public decimal Price { get; init; }
        public int? CategoryId { get; init; }  //Foreign Key

    }
}