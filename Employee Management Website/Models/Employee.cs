using System.ComponentModel.DataAnnotations;

namespace Employee_Management_Website.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [RegularExpression(@"^(([+]961[\s]*(3|7(0|1|6)|81))|(03|7(0|1|6)|81))[\s]*\d{6}$", ErrorMessage = "Please enter a valid phone number in the format (+961) ** ******.")]
        public string Phone { get; set; } = "";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EmploymentDate { get; set; }
        public string PersonalPhoto { get; set; } = "";
        public GovernorateType Governorate { get; set; }
        public bool isProbation { get; set; }
        public bool isDeleted { get; set; } = false;

        public enum GovernorateType
        {
            Akkar,
            Beirut,
            Beqaa, 
            Nabatieh,

        }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
