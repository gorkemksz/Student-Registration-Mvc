using Microsoft.EntityFrameworkCore;
using Student_registration_mvc_with_entity.Models.Entities;

namespace Student_registration_mvc_with_entity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base (options)
        {
        
        }

        public DbSet<Student> Students1 { get; set; }  
    }
}
