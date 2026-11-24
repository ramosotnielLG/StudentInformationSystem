/*
 NIM: 2481032
 Name: Ramos Otniel Lumban Gaol
 Course: Framework .NET Programming
 */

using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Data;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Profile()
        {
            //create a new student object
            Student student = StudentData.Students[0];
            //assign an example of student info

            return View(student);
        }
    }
}
