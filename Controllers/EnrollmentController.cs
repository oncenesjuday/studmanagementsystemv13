using Microsoft.AspNetCore.Mvc;
using studmanagementsystemv13.Models;

public class EnrollmentController : Controller
{
    private readonly StudentContext _studentContext;

    public EnrollmentController(StudentContext studentContext)
    {
        _studentContext = studentContext;
    }

    public IActionResult EnrollmentForm11()
    {
        return View();
    }

    public IActionResult EnrollmentForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult EnrollmentForm11(Students students)
    {
        bool isSuccess = _studentContext.InsertStudent(students);

        if (isSuccess)
        {
            ViewBag.IsSuccess = true;
            ViewBag.Message = "SAVE RJUDDDDDDY AY!!";
        }
        else
        {
            ViewBag.Message = "GI AHAK WALAAAAA";
        }

        return View(students);
    }
    [HttpPost]
    public IActionResult EnrollmentForm(Students students)
    {
        bool isSuccess = _studentContext.InsertStudentLang(students);

        if (isSuccess)
        {
            ViewBag.IsSuccess = true;
            ViewBag.Message = "SAVE RJUDDDDDDY AY!!";
        }
        else
        {
            ViewBag.Message = "GI AHAK WALAAAAA";
        }

        return View(students);
    }
}
