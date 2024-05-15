using System.Linq.Expressions;
using Google.Protobuf;
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

    public IActionResult StudentTable()
    {
        var students = _studentContext.GetStudents();
        return View(students);
    }

    [HttpGet]
    public IActionResult UpdateEnrollmentForm(int id)
    {
        var studentids = _studentContext.GetStudentsById(id);
        return View(studentids);
    }

    [HttpPost]
    public IActionResult UpdateEnrollmentForm(Students updatedstudents)
    {
        try
        {
            int ID = updatedstudents.ID;
            bool isSuccess = _studentContext.UpdateStudent(updatedstudents);

            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Student information updated successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = ID;
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessageCatch"] = $"Error: {ex.Message}";
        }

        return View(updatedstudents);
    }

    [HttpPost]
    public IActionResult DeleteStudent(int id)
    {
        try
        {
            bool isSuccess = _studentContext.DeleteStudent(id);

            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Student deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error deleting student";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessageCatch"] = $"Error: {ex.Message}"; 
        }
        return RedirectToAction("StudentTable");
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
   




