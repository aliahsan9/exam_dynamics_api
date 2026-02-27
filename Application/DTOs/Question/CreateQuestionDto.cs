using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Question
{
    public class CreateQuestionDto
    {
        [Required]
        public int ExamId { get; set; }
        [Required]
        public string QuestionText { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = string.Empty;
        public int Marks { get; set; }
        [Required]
        public List<CreateOptionDto>? Options { get; set; }

    }
}
