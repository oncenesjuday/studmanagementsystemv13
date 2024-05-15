using Microsoft.AspNetCore.Mvc;
using studmanagementsystemv13.Models;

namespace studmanagementsystemv13.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseContext _courseContext;

        public CourseController(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }
        public IActionResult Course()
        {
            return View();
        }
        public IActionResult CourseForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CourseForm(Course course)
        {
            bool isSuccess = _courseContext.InsertCourse(course);

            if (isSuccess)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "SAVE RJUDDDDDDY AY!!";
            }
            else
            {
                ViewBag.Message = "GI AHAK WALAAAAA";
            }

            return View(course);
        }
    }
}
