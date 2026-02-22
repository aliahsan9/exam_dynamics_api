using ExamDynamics.API.Domain.Entities;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamDynamics.API.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // DataSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ChatHistory> ChatHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Unique Slug for Blog, Important for SEO
            builder.Entity<Blog>()
                .HasIndex(b => b.Slug)
                .IsUnique();

            // Relationships
            builder.Entity<Exam>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Question>()
                .HasOne(q => q.Exam)
                .WithMany(e => e.Questions)
                .HasForeignKey(q => q.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentResult>()
                .HasOne(r => r.Exam)
                .WithMany(e => e.Results)
                .HasForeignKey(r => r.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentAnswer>()
                .HasOne(a => a.StudentResult)
                .WithMany(r => r.Answers)
                .HasForeignKey(a => a.StudentResultId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
