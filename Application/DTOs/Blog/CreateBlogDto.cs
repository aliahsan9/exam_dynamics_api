using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Blog
{
    public class CreateBlogDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string Slug { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public string MetaDescription { get; set; } = string.Empty;

    }
}
