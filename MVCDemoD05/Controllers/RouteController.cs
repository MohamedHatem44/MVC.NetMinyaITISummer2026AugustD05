using Microsoft.AspNetCore.Mvc;

namespace MVCDemoD05.Controllers
{
    public class RouteController : Controller
    {
        /*------------------------------------------------------------------*/
        // Get: /Route/Index?name=John&id=42
        public IActionResult Index(string name, int id)
        {
            return Content($"Received Name: {name}, Id: {id}");
        }
        /*------------------------------------------------------------------*/
        [HttpGet("about/{deptId:int}")]
        public IActionResult About1(int deptId)
        {
            return Content($"Received Id: {deptId}");
        }
        /*------------------------------------------------------------------*/
        [HttpGet("about/{deptId:alpha}")]
        public IActionResult About2(string deptId)
        {
            return Content($"Received Id: {deptId}");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        [Route("about3")]
        public IActionResult About3()
        {
            return Content("About 3");
        }
        /*------------------------------------------------------------------*/
    }
}