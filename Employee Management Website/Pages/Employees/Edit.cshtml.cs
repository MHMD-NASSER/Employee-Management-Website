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
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_Website.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly EmployeeServices _employeeService; 

        public EditModel(ApplicationDbContext context , EmployeeServices employeeService)
        {
            _context = context;
            _employeeService = employeeService; 
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;
        [BindProperty]
        public IFormFile Photo { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _employeeService.GetEmployeeById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Photo != null && Photo.Length > 0)
            {
                _employeeService.AddPhoto(Photo, Employee);
            }
            await _employeeService.UpdateEmployee(Employee);

            return RedirectToPage("./Index");
        }

    }
}
