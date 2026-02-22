using System.ComponentModel.DataAnnotations.Schema;

namespace ExamDynamics.API.Domain.Entities
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public int StudentResultId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public bool IsCorrect { get; set; }
        [ForeignKey("StudentResultId")]
        public StudentResult? StudentResult { get; set; }
    }
}
