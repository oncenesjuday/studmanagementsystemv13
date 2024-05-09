using Microsoft.AspNetCore.Mvc;
using studmanagementsystemv13.Models;

namespace studmanagementsystemv13.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorContext _instructorContext;

        public InstructorController(InstructorContext instructorContext)
        {
            _instructorContext = instructorContext;
        }
        public IActionResult InstructorForm()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult InstructorForm(Instructor instructor)
        {
            bool isSuccess = _instructorContext.InsertInstructor(instructor);

            if (isSuccess)
            {
                ViewBag.IsSuccess = true;
                ViewBag.Message = "SAVE RJUDDDDDDY AY!!";
            }
            else
            {
                ViewBag.Message = "GI AHAK WALAAAAA";
            }

            return View(instructor);
        }
    }
}
