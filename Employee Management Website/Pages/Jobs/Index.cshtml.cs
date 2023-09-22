using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Employee_Management_Website.Services;

namespace Employee_Management_Website.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly JobServices _jservice; 
        readonly EmployeeServices _employeeServices;
        public IndexModel(ApplicationDbContext context, JobServices jservices,EmployeeServices employeeServices)
        {
            _context = context;
            _jservice = jservices;
            _employeeServices = employeeServices;
        }

        public List<Job> Job { get; set; }




        [BindProperty(SupportsGet = true)]
        public int? JobId { get; set; }

        public List<string>? Employees { get; set; }

        [BindProperty]
        public string JobName { get; set; }

        public async Task OnGetAsync()
        {
            Job = await _jservice.GetAllJobs();
            if (JobId.HasValue)
            {
                Employees = await _employeeServices.GetEmployeesByJob(JobId);
                JobName = (await _jservice.GetJobById(JobId.Value)).Name; 
            }
        }

    }
}
