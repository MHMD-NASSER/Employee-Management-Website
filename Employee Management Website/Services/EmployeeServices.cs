using Employee_Management_Website.Database;
using Employee_Management_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Website.Services
{
    public class EmployeeServices
    {
        private readonly ApplicationDbContext _context;

        public EmployeeServices(ApplicationDbContext c)
        {
            _context = c;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.employees.ToListAsync();
        }
        public async Task AddEmployee(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.employees.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task UpdateEmployee(Employee employee)
        {
            _context.Attach(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(Employee employee)
        {
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

        }
        
        public Employee AddPhoto(IFormFile photo, Employee employees)
        {
            var file = photo;
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = "wwwroot/Images/" + uniqueFileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (photo != null)
            {
                employees.PersonalPhoto = $"~/Images/{uniqueFileName}";
            }
            return employees;
        }


        public async Task<List<string>>  GetEmployeesByJob(int? jobId)
        {
            return   _context.employees
                .Where(e => e.Jobs.Any(j => j.Id == jobId)).Select(e => e.Name)
                .ToList();
        }

        public async Task<List<Employee>> GetAllActiveEmployees()
        {
            return await _context.employees.Where(e => e.Jobs !=null ).ToListAsync();
        }
        public async Task<List<Employee>> GetAllEmployeesByName(string ename)
        {
            return await _context.employees.Where(e => e.Name == ename).ToListAsync();
        }
        public async Task<List<Employee>> GetAllEmployeesByJob(string jname)
        {
            return await _context.employees.Where(e => e.Name == jname).ToListAsync();
        }



    }
}
