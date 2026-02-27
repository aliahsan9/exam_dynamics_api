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
            if (dto.Options.Count < 2)
                return BadRequest("Atleast two options are required!");

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

            foreach(var opt in dto.Options)
            {
                var option = new Option
                {
                    QuestionId = question.Id,
                    OptionText = opt.OptionText,
                    IsCorrect = opt.IsCorrect
                };
                _context.Options.Add(option);

                await _context.SaveChangesAsync();
                return Ok("Question Created!");
            }
        }

    }
}
