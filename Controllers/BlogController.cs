using ExamDynamics.API.Application.DTOs.Blog;
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
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= GET ALL BLOGS =================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _context.Blogs
                .Where(b => b.IsPublished)
                .OrderByDescending(b => b.CreatedAt)
                .Select(b => new BlogListDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Slug = b.Slug,
                    ImageUrl = b.ImageUrl,
                    CreatedAt = b.CreatedAt
                })
                .ToListAsync();

            return Ok(blogs);
        }

        // ================= GET BLOG BY SLUG =================
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var blog = await _context.Blogs
                .Include(b => b.Author)
                .Where(b => b.Slug == slug && b.IsPublished)
                .Select(b => new BlogDetailDto
                {
                    Title = b.Title,
                    Content = b.Content,
                    ImageUrl = b.ImageUrl,
                    CreatedAt = b.CreatedAt,
                    AuthorName = b.Author.FullName
                })
                .FirstOrDefaultAsync();

            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        // ================= CREATE BLOG (ADMIN) =================
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto dto)
        {
            var adminId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier));

            var blog = new Blog
            {
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                ImageUrl = dto.ImageUrl,
                IsPublished = dto.IsPublished,
                MetaDescription = dto.MetaDescription,
                AuthorId = adminId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return Ok(blog);
        }

        // ================= DELETE BLOG =================
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound();

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return Ok("Blog deleted");
        }
    }
}