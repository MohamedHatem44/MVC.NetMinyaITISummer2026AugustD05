using Microsoft.AspNetCore.Mvc;

namespace MVCDemoD05.Controllers
{
    public class StateManagementController : Controller
    {
        /*------------------------------------------------------------------*/
        #region TempData
        //// TempData is used to store data that needs to
        //// Present data to the next request, typically after a redirect.
        //public IActionResult SetTempData()
        //{
        //    TempData["Message"] = "Hello from TempData";
        //    return Content("TempData Saved");
        //}

        //public IActionResult GetTempData1()
        //{
        //    //// Normal Read
        //    //string? message = TempData["Message"]?.ToString();
        //    //return Content(message ?? "No Message in TempData");

        //    //// Peek Read (Does not remove the data from TempData)
        //    //string? message = TempData.Peek("Message")?.ToString();
        //    //return Content(message ?? "No Message in TempData");

        //    // Keep Read (Keeps the data for the next request)
        //    string? message = TempData["Message"]?.ToString();
        //    TempData.Keep(); // Keep all TempData for the next request
        //    TempData.Keep("Message"); // Keep only the "Message" key for the next request
        //    return Content(message ?? "No Message in TempData");
        //}

        //public IActionResult GetTempData2()
        //{
        //    // Normal Read (Removes the data from TempData)
        //    string? message = TempData["Message"]?.ToString();
        //    return Content(message ?? "No Message in TempData");
        //}
        #endregion
        /*------------------------------------------------------------------*/
        #region Session
        //// Session is used to store data that needs to persist
        //// across multiple requests from the same user.
        //// Valid until the session expires or is cleared.
        //public IActionResult SetSession()
        //{
        //    HttpContext.Session.SetString("Message", "Hello from Session");
        //    HttpContext.Session.SetInt32("Age", 42);
        //    return Content("Session Saved");
        //}

        //public IActionResult GetSession()
        //{
        //    string? message = HttpContext.Session.GetString("Message");
        //    int? Age = HttpContext.Session.GetInt32("Age");
        //    return Content($"Message: {message ?? "No Message in Session"}, Age: {Age?.ToString() ?? "No Age in Session"}");
        //}
        #endregion
        /*------------------------------------------------------------------*/
        #region Cookies
        //public IActionResult SetCookie()
        //{
        //    CookieOptions options = new CookieOptions
        //    {
        //        Expires = DateTime.Now.AddMinutes(30), // Set cookie expiration
        //        HttpOnly = true, // Make the cookie HTTP-only
        //        IsEssential = true // Make the cookie essential
        //    };

        //    Response.Cookies.Append("Message", "Hello from Cookie", options);
        //    return Content("Cookie Saved");
        //}

        //public IActionResult GetCookie()
        //{
        //    string? message = Request.Cookies["Message"];
        //    return Content($"Message: {message ?? "No Message in Cookie"}");
        //}
        #endregion
        /*------------------------------------------------------------------*/
    }
}