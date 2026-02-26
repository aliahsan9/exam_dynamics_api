namespace ExamDynamics.API.Application.DTOs.Exam
{
    public class ExamListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; } 
    }
}
                                    