using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamics.API.Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string OptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        // Navigation
        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }

    }
}
