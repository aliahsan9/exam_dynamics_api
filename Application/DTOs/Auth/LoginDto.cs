using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Application.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
