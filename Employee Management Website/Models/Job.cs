using System.ComponentModel.DataAnnotations;

namespace Employee_Management_Website.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public CategoryType Category { get; set; }

        public enum CategoryType
        {
            First,
            Second,
            Third
        }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
