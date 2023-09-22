using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Employee_Management_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_Website.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly EmployeeServices _employeeService;

        public CreateModel(ApplicationDbContext context, EmployeeServices employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        [BindProperty]
        [Required]
        public IFormFile Photo { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid )
            {
                return Page();
            }
            if (Photo != null && Photo.Length > 0)
            {
                _employeeService.AddPhoto(Photo, Employee); 
            }

            await _employeeService.AddEmployee(Employee);

            return RedirectToPage("./Index");
        }
        

    }
}
