using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Website.Services
{
    public class JobServices
    {
        private readonly ApplicationDbContext _context;
        public JobServices(ApplicationDbContext c)
        {
            _context = c;
        }

        public async Task<List<Job>> GetAllJobs()
        {
           return await _context.Jobs.ToListAsync();    
        }
        public async Task AddJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }
        public async Task<Job> GetJobById(int id)
        {
            return await _context.Jobs.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task UpdateJob(Job job)
        {
            _context.Attach(job).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }
        public async Task DeleteJob(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Job>> GetJobsByEmployee(int? jobId)
        {
            return _context.Jobs
                .Where(e => e.Employees.Any(j => j.Id == jobId))
                .ToList();
        }

    }
}
