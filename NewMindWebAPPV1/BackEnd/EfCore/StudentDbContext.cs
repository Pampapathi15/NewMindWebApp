using BackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace BackEnd.EfCore
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

    }
}
