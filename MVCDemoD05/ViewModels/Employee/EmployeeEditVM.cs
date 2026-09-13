using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MVCDemoD05.ViewModels.Employee
{
    public class EmployeeEditVM
    {
        #region Get From Form
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        #endregion

        #region Sent To Form
        public List<SelectListItem>? Departments { get; set; }
        #endregion
    }
}