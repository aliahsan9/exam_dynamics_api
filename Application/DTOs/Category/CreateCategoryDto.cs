using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
    }
}
