using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
