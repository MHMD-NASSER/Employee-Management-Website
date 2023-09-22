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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly JobServices _jobServices;

        public DeleteModel(ApplicationDbContext context , JobServices jobServices)
        {
            _context = context;
            _jobServices = jobServices; 
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Job =  await _jobServices.GetJobById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _jobServices.DeleteJob(Job); 

            return RedirectToPage("./Index");
        }
    }
}
