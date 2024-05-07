using Microsoft.AspNetCore.Mvc;
using studmanagementsystemv13.Models;

namespace studmanagementsystemv13.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult InstructorForm()
        {
            return View();
        }
    }
}
