using CleanArchMvc.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The {0} is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [Range(1, 9999)]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; set; } = string.Empty;
        
        [DisplayName("Categories")]
        public required Category Category { get; set; }

        public int CategoryId { get; set; }

    }
}
