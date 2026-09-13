using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoD05.ViewModels.Employee
{
    public class EmployeeCreateVM
    {
        #region Get From Form
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Range(18, 50, ErrorMessage = "Range 18 ~ 50")]
        public int Age { get; set; }

        [Required]
        [Range(2000, 5000)]
        public decimal Salary { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        #endregion

        #region Sent To Form
        public List<SelectListItem>? Departments { get; set; }
        #endregion
    }
}