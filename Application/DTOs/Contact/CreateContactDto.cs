using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Contact
{
    public class CreateContactDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
