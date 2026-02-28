using ExamDynamics.API.Application.DTOs.Question;
using ExamDynamics.API.Domain.Entities;
using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class QuestionsController : ControllerBase     
    {
        private readonly ApplicationDbContext _context;
        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request data.");

            if (dto.Options == null || dto.Options.Count < 2)
                return BadRequest("At least two options are required!");

            var question = new Question
            {
                ExamId = dto.ExamId,
                QuestionText = dto.QuestionText,
                Explanation = dto.Explanation,
                DifficultyLevel = dto.DifficultyLevel,
                Marks = dto.Marks
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            foreach (var opt in dto.Options)
            {
                var option = new Option
                {
                    QuestionId = question.Id,
                    OptionText = opt.OptionText,
                    IsCorrect = opt.IsCorrect
                };

                _context.Options.Add(option);
            }

            // Save ALL options at once (better performance)
            await _context.SaveChangesAsync();

            return Ok("Question Created Successfully!");
        }

    }
}
