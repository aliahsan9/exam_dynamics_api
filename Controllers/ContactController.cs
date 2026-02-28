using ExamDynamics.API.Application.DTOs.Contact;
using ExamDynamics.API.Domain.Entities;
using ExamDynamics.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExamDynamics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactController (ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto dto)
        {
            var message = new ContactMessage
            {
                Name = dto.Name,
                Email = dto.Email,
                Message = dto.Message
            };
            _context.ContactMessages.Add(message);
            await _context.SaveChangesAsync();

            return Ok("Message sent successfully...");

        }
    }
}
