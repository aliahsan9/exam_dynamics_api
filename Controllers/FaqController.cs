using ExamDynamics.API.Application.DTOs.Faq;
using ExamDynamics.API.Domain.Entities;
using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FaqController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faq = await _context.Faqs
                .OrderBy(f => f.DisplayOrder)
                .ToListAsync();
            return Ok(faq);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateFaqDto dto)
        {
            var faq = new Faq
            {
                Question = dto.Question,
                Answer = dto.Answer,
                DisplayOrder = dto.DisplayOrder
            };

            _context.Faqs.Add(faq);
            await _context.SaveChangesAsync();

            return Ok(faq);
        }
    }
}
