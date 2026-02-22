using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; }

        // Navigation Properties
        public ICollection<StudentResult>? Results { get; set; }
        public ICollection<ChatHistory>? ChatHistories { get; set; }
        public ICollection<Blog>? Blogs { get; set; }

    }
}
