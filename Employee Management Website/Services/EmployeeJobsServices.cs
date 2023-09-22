using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Website.Services
{
    public class EmployeeJobsServices
    {
        private readonly ApplicationDbContext _context;
        public EmployeeJobsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        // Assign employee to a job
        public void AssignEmployeeToJob(int employeeId, string jobName)
        {
            var employee = _context.employees.FirstOrDefault(e => e.Id == employeeId);
            var job = _context.Jobs.FirstOrDefault(j => j.Name == jobName);

            bool found = false;
            List<Job> jobs = _context.Jobs
                .Where(e => e.Employees.Any(j => j.Id == job.Id))
                .ToList(); 

            if ( jobs.Count != 0)
            {
                found = true;
            }

            if (employee != null && job != null && found==false)
            {
                employee.Jobs.Add(job);
                _context.SaveChanges();
                job.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        // Deactivate employee from a job
        public void DeactivateEmployeeFromJob(int employeeId, int jobId)
        {
            var employee = _context.employees.FirstOrDefault(e => e.Id == employeeId);
            var job = _context.Jobs.FirstOrDefault(j => j.Id == jobId);

            if (employee != null && job != null)
            {
                employee.Jobs.Remove(job);
                _context.SaveChanges();
                job.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

    }

}

