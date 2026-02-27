using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Question
{
    public class CreateOptionDto
    {
        [Required]
        public string OptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }                                                                             
}
