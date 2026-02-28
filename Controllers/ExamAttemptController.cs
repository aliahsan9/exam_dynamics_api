using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExamAttemptController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamAttemptController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= START EXAM =================
        [HttpGet("start/{examId}")]
        public async Task<IActionResult> StartExam(int examId)
        {
            var questions = await _context.Questions
                .Where(q => q.ExamId == examId)
                .Include(q => q.Options)
                .Select(q => new
                {
                    q.Id,
                    q.QuestionText,
                    Options = q.Options.Select(o => new
                    {
                        o.Id,
                        o.OptionText
                    })
                })
                .ToListAsync();

            return Ok(questions);
        }

        // ================= SUBMIT EXAM =================
        [HttpPost("submit/{examId}")]
        public async Task<IActionResult> SubmitExam(
            int examId,
            Dictionary<int, int> answers)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier));

            var questions = await _context.Questions
                .Where(q => q.ExamId == examId)
                .Include(q => q.Options)
                .ToListAsync();

            int correct = 0;

            var result = new Domain.Entities.StudentResult
            {
                UserId = userId,
                ExamId = examId,
                TotalQuestions = questions.Count,
                DateTaken = DateTime.UtcNow
            };

            _context.StudentResults.Add(result);
            await _context.SaveChangesAsync();

            foreach (var question in questions)
            {
                var correctOption = question.Options.First(o => o.IsCorrect);

                answers.TryGetValue(question.Id, out int selectedOptionId);

                bool isCorrect = correctOption.Id == selectedOptionId;

                if (isCorrect)
                    correct++;

                var studentAnswer = new Domain.Entities.StudentAnswer
                {
                    StudentResultId = result.Id,
                    QuestionId = question.Id,
                    SelectedOptionId = selectedOptionId,
                    IsCorrect = isCorrect
                };

                _context.StudentAnswers.Add(studentAnswer);
            }

            result.CorrectAnswers = correct;
            result.Score = correct;
            result.Percentage =
                (double)correct / questions.Count * 100;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                result.Score,
                result.TotalQuestions,
                result.CorrectAnswers,
                result.Percentage
            });
        }
    }
}