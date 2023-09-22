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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        readonly EmployeeServices _employeeServices;


        public IndexModel(ApplicationDbContext context , EmployeeServices employeeService)
        {
            _context = context;
            _employeeServices = employeeService;
        }

        public List<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        { 
            Employee = await _employeeServices.GetAllEmployees();
        }

    }
}
