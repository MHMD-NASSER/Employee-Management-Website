using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Employee_Management_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_Website.Pages.EmployeeJobs
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        readonly EmployeeServices _employeeServices; 
        readonly JobServices _jobServices;
        readonly EmployeeJobsServices _employeeJobsServices; 

        public IndexModel(ApplicationDbContext context, EmployeeServices employeeServices, JobServices jobServices, EmployeeJobsServices employeeJobsServices)
        {
            _context = context;
            _employeeServices = employeeServices;
            _jobServices = jobServices;
            _employeeJobsServices = employeeJobsServices; 
        }

        public Employee Employee { get; set; } = default!;
        public List<Job> EmployeeJobs { get; set; } = default!;
        public List<Job> jobs { get; set; }
        [Required]
        [BindProperty]
        public string SelectedJob { get; set; }
        [BindProperty]
        public int Eid { get; set; }
        public async Task OnGet(int id)
        {
            Employee = await _employeeServices.GetEmployeeById(id);
            EmployeeJobs = await _jobServices.GetJobsByEmployee(id);
            jobs = await _jobServices.GetAllJobs();
            this.Eid = Employee.Id;
        }
        public async Task<IActionResult> OnPostAddJob()
        {
            if(SelectedJob != null)
            {
                _employeeJobsServices.AssignEmployeeToJob(Eid, SelectedJob);

            }
            return RedirectToPage("/Employees/Index");
        }


        public async Task<IActionResult> OnPostDelete(int Jid)
        {
            _employeeJobsServices.DeactivateEmployeeFromJob( Eid, Jid);
            return RedirectToPage("/Employees/Index");
        }

        
    }
}
