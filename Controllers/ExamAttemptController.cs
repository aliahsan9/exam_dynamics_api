using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [Authorize]
    public class ExamAttemptController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ExamAttemptController (ApplicationDbContext context)
        {
            _context = context;
        }
        // Start Exam
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
                    Options = q.Options
                    .Select(o => new
                    {
                        o.Id,
                        o.OptionText
                    })
                })
                .ToListAsync();
            return Ok(questions);
        }
        // Submit Exam
        [HttpPost("start/{examId}")]
        public async Task<IActionResult> StartExam(int examId)
        {
            var questions = _context.Questions
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

    }
}
