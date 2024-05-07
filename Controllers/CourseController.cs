using Microsoft.AspNetCore.Mvc;

namespace studmanagementsystemv13.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult CourseForm()
        {
            return View();
        }
    }
}
