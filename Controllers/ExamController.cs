using ExamDynamics.API.Application.DTOs.Exam;
using ExamDynamics.API.Domain.Entities;
using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/exams
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exams = await _context.Exams
                .Include(e => e.Category)
                .Select(e => new ExamListDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Category = e.Category.Name,
                    DurationMinutes = e.DurationMinutes,
                    TotalMarks = e.TotalMarks
                })
                .ToListAsync();

            return Ok(exams);
        }

        // POST: api/exams
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto dto)
        {
            var adminId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var exam = new Exam
            {
                Title = dto.Title,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                DurationMinutes = dto.DurationMinutes,
                TotalMarks = dto.TotalMarks,
                PassingMarks = dto.PassingMarks,
                CreatedBy = adminId
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return Ok(exam);
        }
    }
}