using System.ComponentModel.DataAnnotations;

namespace ExamDynamics.API.Domain.Entities
{
    public class Faq
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Question { get; set; } = string.Empty;
        [Required]
        [MaxLength(2000)]
        public string Answer { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } 
    }
}
