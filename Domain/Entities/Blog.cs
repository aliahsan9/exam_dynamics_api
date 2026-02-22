using OpenAI.Responses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamics.API.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string Slug { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [MaxLength(500)]

        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid AuthorId { get; set; }
        public bool IsPublished { get; set; }
        [MaxLength(300)]
        public string MetaDescription { get; set; } = string.Empty;

        // Navigation
        [ForeignKey("AuthorId")]
        public ApplicationUser? Author { get; set; }
    }
}
