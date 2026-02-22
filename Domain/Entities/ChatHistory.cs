using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamics.API.Domain.Entities
{
    public class ChatHistory
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string UserMessage { get; set; } = string.Empty;
        public string AIResponse { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

    }
}
