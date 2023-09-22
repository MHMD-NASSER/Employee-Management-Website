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

namespace Employee_Management_Website.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly EmployeeServices _employeeService; 

        public DeleteModel(ApplicationDbContext context , EmployeeServices employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _employeeService.GetEmployeeById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        { 
            Employee = await _employeeService.GetEmployeeById(id);
            await _employeeService.DeleteEmployee(Employee);

            return RedirectToPage("./Index");
        }

    }
}
