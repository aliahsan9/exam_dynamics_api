using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsPublished { get; set; } = true;

    }
}
