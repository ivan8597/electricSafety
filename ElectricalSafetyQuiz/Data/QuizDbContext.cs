using ElectricalSafetyQuiz.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectricalSafetyQuiz.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
} 