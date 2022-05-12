using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs
{
    public record CreateItemDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}