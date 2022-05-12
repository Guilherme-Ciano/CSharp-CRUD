using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs
{
    public record UpdateItemDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
    }
}