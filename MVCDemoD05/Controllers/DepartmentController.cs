using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemoD05.Context;
using MVCDemoD05.Models;
using MVCDemoD05.ViewModels.Department;

namespace MVCDemoD05.Controllers
{
    public class DepartmentController : Controller
    {
        /*------------------------------------------------------------------*/
        // Context
        private readonly AppDbContext db = new AppDbContext();
        /*------------------------------------------------------------------*/  
        [HttpGet]
        public IActionResult Index()
        {
            var departmentsReadVM = db.Departments
                .Include(d => d.Employees)
                .Select(d => new DepartmentReadVM
                {
                    DepartmentId = d.DepartmentId,
                    Name = d.Name,
                    EmployeesCount = d.Employees.Count
                }).ToList();

            return View(departmentsReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = db.Departments
                .Include(d => d.Employees)
                .FirstOrDefault(d => d.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }

            var departmentReadVM = new DepartmentReadVM
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name,
                EmployeesCount = department.Employees.Count
            };

            return View(departmentReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(DepartmentCreateVM departmentCreateVM)
        {
            var department = new Department
            {
                Name = departmentCreateVM.Name
            };

            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            var departmentEditVM = new DepartmentEditVM
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };

            return View(departmentEditVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(DepartmentEditVM departmentEditVM)
        {
            var departmentInDB = db.Departments.FirstOrDefault(d => d.DepartmentId == departmentEditVM.DepartmentId);
            if (departmentInDB == null)
            {
                return NotFound();
            }

            departmentInDB.Name = departmentEditVM.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}