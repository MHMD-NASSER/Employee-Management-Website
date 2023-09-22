using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Employee_Management_Website.Services;

namespace Employee_Management_Website.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly JobServices _jobServices;

        public CreateModel(ApplicationDbContext context, JobServices jobServices)
        {
            _context = context;
            _jobServices = jobServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Jobs == null || Job == null)
            {
                return Page();
            }
            await _jobServices.AddJob(Job);

            return RedirectToPage("./Index");
        }
    }
}
