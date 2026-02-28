using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Faq
{
    public class CreateFaqDto
    {
        [Required]
        public string Question { get; set; } = string.Empty;
        [Required]
        public string Answer { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } 
    }
}
