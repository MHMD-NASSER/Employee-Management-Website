using Employee_Management_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Website.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Job> Jobs { get; set; } 
        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                    .HasMany(e => e.Jobs)
                    .WithMany(j => j.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeJob",
                        e => e.HasOne<Job>().WithMany(),
                        j => j.HasOne<Employee>().WithMany()
                    );

            base.OnModelCreating(modelBuilder);
        }


    }
}
