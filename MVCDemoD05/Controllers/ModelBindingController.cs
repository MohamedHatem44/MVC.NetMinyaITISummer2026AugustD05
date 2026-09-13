using Microsoft.AspNetCore.Mvc;
using MVCDemoD05.Models;

namespace MVCDemoD05.Controllers
{
    public class ModelBindingController : Controller
    {
        /*------------------------------------------------------------------*/
        // Model Binding is the process of 
        // Mapping data from HTTP requests to action method parameters.
        // Allow you to work with strongly typed objects instead of raw request data.
        public IActionResult Index()
        {
            var age = HttpContext.Request.Query["age"].ToString();
            return View();
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PreimitiveModelBinding1?id=42
        // ~/ModelBinding/PreimitiveModelBinding1/42
        public IActionResult PreimitiveModelBinding1(int id)
        {
            return Content($"Recevied Id: {id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PreimitiveModelBinding2?empId=42
        // ~/ModelBinding/PreimitiveModelBinding2/42 XXXXXXXX
        public IActionResult PreimitiveModelBinding2(int empId)
        {
            return Content($"Recevied Id: {empId}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PreimitiveModelBinding3?empId=42
        // ~/ModelBinding/PreimitiveModelBinding3?empId=42&name=John
        public IActionResult PreimitiveModelBinding3(int empId, string name)
        {
            return Content($"Recevied Id: {empId}, Name: {name}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ArrayModelBinding4?empId=42&colors[1]=red&colors[0]=green&colors[2]=blue
        // ~/ModelBinding/ArrayModelBinding4?empId=42&colors=red&colors=green&colors=blue
        public IActionResult ArrayModelBinding4(int empId, string[] colors)
        {
            return Content($"Recevied Id: {empId}, Colors: {string.Join(", ", colors)}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/CollectionModelBinding5?phones[home]=123&phones[work]=456&phones[mobile]=789
        public IActionResult CollectionModelBinding5(Dictionary<string, int> phones)
        {
            return Content($"Recevied Phones: {string.Join(", ", phones.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ComplexModelBinding6?DepartmentId=1&Name=HR
        public IActionResult ComplexModelBinding6(Department department)
        {
            return Content($"Recevied Department: Id: {department.DepartmentId}, Name: {department.Name}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ComplexModelBinding7?DepartmentId=1&Name=HR&employees[0].Id=101&employees[0].Name=Alice
        public IActionResult ComplexModelBinding7(Department department)
        {
            return Content($"Recevied Department: Id: {department.DepartmentId}, Name: {department.Name}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/ComplexModelBinding8?DepartmentId=1&Name=HR&employees[0].Id=101&employees[0].Name=Alice
        public IActionResult ComplexModelBinding8([Bind(include: "Id, Name")] Department department)
        {
            return Content($"Recevied Department: Id: {department.DepartmentId}, Name: {department.Name}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PreimitiveModelBinding9?id=42 XXXXXXXXXX
        // ~/ModelBinding/PreimitiveModelBinding9/42
        public IActionResult PreimitiveModelBinding9([FromRoute] int id)
        {
            return Content($"Recevied Id: {id}");
        }
        /*------------------------------------------------------------------*/
        // ~/ModelBinding/PreimitiveModelBinding10?id=42
        // ~/ModelBinding/PreimitiveModelBinding10/42 XXXXXXXXXX
        public IActionResult PreimitiveModelBinding10([FromQuery] int id)
        {
            return Content($"Recevied Id: {id}");
        }
        /*------------------------------------------------------------------*/
    }
}