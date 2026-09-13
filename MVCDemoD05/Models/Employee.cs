using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoD05.Models
{
    public class Employee
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [Range(18, 50)]
        public int Age { get; set; }

        [Required]
        [Range(2000,5000)]
        public decimal Salary { get; set; }
        /*------------------------------------------------------------------*/
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        /*------------------------------------------------------------------*/
    }
}