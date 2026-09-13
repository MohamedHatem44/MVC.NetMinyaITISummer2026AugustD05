using System.ComponentModel;

namespace MVCDemoD05.ViewModels.Department
{
    public class DepartmentReadVM
    {
        [DisplayName("Dept Id")] // UI Only
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public int EmployeesCount { get; set; }
    }
}