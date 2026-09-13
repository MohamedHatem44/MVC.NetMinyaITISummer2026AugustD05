namespace MVCDemoD05.Models
{
    public class Department
    {
        /*------------------------------------------------------------------*/
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        /*------------------------------------------------------------------*/
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        /*------------------------------------------------------------------*/
    }
}