using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamDynamics.API.Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [Required]
        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; }
        public int PassingMarks { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; }  

        // Navigation
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } 

        public ICollection<Question>? Questions { get; set; }
        public ICollection<StudentResult>? Results { get; set; }

    }
}