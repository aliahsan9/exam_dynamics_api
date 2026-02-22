using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamics.API.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public int ExamId { get; set; }
        [Required]
        [MaxLength(2000)]
        public string QuestionText { get; set; } = string.Empty;
        [MaxLength(2000)]
        public string Explanation { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string DifficultyLevel { get; set; } = string.Empty; // Easy, Medium & Hard
        public int Marks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation 
        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }
        public ICollection<Option>? Options { get; set; }

    }
}