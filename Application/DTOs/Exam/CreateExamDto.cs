using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Exam
{
    public class CreateExamDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; }
        public int PassingMarks { get; set; }

    }
}
