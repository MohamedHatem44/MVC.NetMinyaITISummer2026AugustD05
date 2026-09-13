using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCDemoD05.Context;
using MVCDemoD05.Models;
using MVCDemoD05.ViewModels.Employee;

namespace MVCDemoD05.Controllers
{
    public class EmployeeController : Controller
    {
        /*------------------------------------------------------------------*/
        // Context
        private readonly AppDbContext db = new AppDbContext();
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            // Mapping to ViewModel
            var employeesReadVM = db.Employees
                .Include(e => e.Department)
                .Select(e => new EmployeeReadVM
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Salary = e.Salary,
                    Department = e.Department!.Name
                }).ToList();

            return View(employeesReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = db.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeReadVM = new EmployeeReadVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Department = employee.Department!.Name
            };

            return View(employeeReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV01()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult CreateV01(Employee employee)
        {
            ModelState.Remove("Department");
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "Name");
                return View(employee);
            }

            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV02()
        {
            var employeeCreateVM = new EmployeeCreateVM
            {
                Departments = GetDepartmentsForDropDown()
            };

            return View(employeeCreateVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult CreateV02(EmployeeCreateVM employeeCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors and try again.");
                employeeCreateVM.Departments = GetDepartmentsForDropDown();
                return View(employeeCreateVM);
            }

            //var employeeWithSameEmail = db.Employees.FirstOrDefault(e => e.Email == employeeCreateVM.Email);
            //if (employeeWithSameEmail != null)
            //{
            //    ModelState.AddModelError("Email", "Email already exists.");
            //    employeeCreateVM.Departments = GetDepartmentsForDropDown();
            //    return View(employeeCreateVM);
            //}

            // Select List => Null
            // Create Domain Model from ViewModel
            var employee = new Employee
            {
                Name = employeeCreateVM.Name,
                Age = employeeCreateVM.Age,
                Salary = employeeCreateVM.Salary,
                DepartmentId = employeeCreateVM.DepartmentId
            };

            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = db.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeEditVM = new EmployeeEditVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department!.Name,
                Departments = GetDepartmentsForDropDown()
            };

            return View(employeeEditVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(EmployeeEditVM employeeEditVM)
        {
            var employeeInDB = db.Employees.FirstOrDefault(e => e.Id == employeeEditVM.Id);
            if (employeeInDB == null)
            {
                return NotFound();
            }

            employeeInDB.Name = employeeEditVM.Name;
            employeeInDB.Age = employeeEditVM.Age;
            employeeInDB.Salary = employeeEditVM.Salary;
            employeeInDB.DepartmentId = employeeEditVM.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        // DRY: Don't Repeat Yourself
        // Helper Method to get Departments for DropDown
        private List<SelectListItem> GetDepartmentsForDropDown()
        {
            return db.Departments
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.Name
                }).ToList();
        }
        /*------------------------------------------------------------------*/
    }
}