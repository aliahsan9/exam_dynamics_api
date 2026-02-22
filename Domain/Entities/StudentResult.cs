using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamics.API.Domain.Entities
{
    public class StudentResult
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime DateTaken { get; set; } = DateTime.UtcNow;
        public int TimeTaken { get; set; } // In Minutes
        public double Percentage { get; set; }    

        // Navigation
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        [ForeignKey("ExamId")]
        public Exam? Exam { get; set; }  
        public ICollection<StudentAnswer>? Answers { get; set; }


    }
}
