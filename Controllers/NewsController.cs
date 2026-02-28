using ExamDynamics.API.Application.DTOs.News;
using ExamDynamics.API.Domain.Entities;
using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = await _context.News
                .Where(n => n.IsPublished)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return Ok(news);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create (CreateNewsDto dto)
        {
            var news = new News
            {
                Title = dto.Title,
                Content = dto.Content,
                IsPublished = dto.IsPublished
            };
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return Ok(news);
        }
    }
}
