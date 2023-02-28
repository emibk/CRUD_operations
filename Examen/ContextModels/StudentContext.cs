using Microsoft.EntityFrameworkCore;
using Examen.Models;
namespace Examen.ContextModels
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options){ }
        public DbSet<Student> Student { get; set; }
        public DbSet<Grupa> Grupa { get; set; }

    }
}
