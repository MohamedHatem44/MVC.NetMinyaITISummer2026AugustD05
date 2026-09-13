using Microsoft.EntityFrameworkCore;
using MVCDemoD05.Models;

namespace MVCDemoD05.Context
{
    public class AppDbContext : DbContext
    {
        /*------------------------------------------------------------------*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=MOHAMED-HATEM\\SQLEXPRESS;DataBase=MVCDay05;Trusted_Connection=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
        /*------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                   .HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .IsRequired();

            // Seeding
            var departments = new List<Department>()
            {
                new Department { DepartmentId = 1, Name = "IT" },
                new Department { DepartmentId = 2, Name = "HR" },
                new Department { DepartmentId = 3, Name = "Finance" },
                new Department { DepartmentId = 4, Name = "BS" },
            };

            var employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Mohamed", Age = 30, Salary = 5000, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Ahmed", Age = 25, Salary = 4000, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Ali", Age = 35, Salary = 6000, DepartmentId = 3 },
                new Employee { Id = 4, Name = "Sara", Age = 28, Salary = 4500, DepartmentId = 1 },
                new Employee { Id = 5, Name = "Mona", Age = 32, Salary = 5500, DepartmentId = 2 },
                new Employee { Id = 6, Name = "Mohamed", Age = 30, Salary = 5000, DepartmentId = 1 },
                new Employee { Id = 7, Name = "Ahmed", Age = 25, Salary = 4000, DepartmentId = 2 },
                new Employee { Id = 8, Name = "Ali", Age = 35, Salary = 6000, DepartmentId = 3 },
                new Employee { Id = 9, Name = "Sara", Age = 28, Salary = 4500, DepartmentId = 1 },
                new Employee { Id = 10, Name = "Mona", Age = 32, Salary = 5500, DepartmentId = 2 },
            };

            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Employee>().HasData(employees);
        }
        /*------------------------------------------------------------------*/
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        /*------------------------------------------------------------------*/
    }
}