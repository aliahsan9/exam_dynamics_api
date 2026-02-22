using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Domain.Entities
{
    public class Category
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        // Navigation
        public ICollection<Exam>? Exams { get; set; }
    }
}
