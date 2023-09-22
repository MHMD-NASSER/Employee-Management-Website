using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Employee_Management_Website.Services;

namespace Employee_Management_Website.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly JobServices _jobServices;

        public EditModel(ApplicationDbContext context , JobServices jobServices)
        {
            _context = context;
            _jobServices = jobServices;
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            Job = await _jobServices.GetJobById(id);
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _jobServices.UpdateJob(Job);

            return RedirectToPage("./Index");
        }

    }
}
