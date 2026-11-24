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
    //indicates this controller provides API endpoints
    [ApiController]

    //Defines the base URL for this API
    [Route("api/students")]
    public class StudentsApiController : ControllerBase
    {
        //GET: /api/students
        //Returns all students as JSON
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            //retrive all students from shared data
            List<Student> students = StudentData.Students;
            return Ok(students);
        }

        [HttpGet("{nim}")]
        public ActionResult<Student> GetStudentByNIM(string nim)
        {
            Student? student = StudentData.Students.FirstOrDefault(s => s.NIM == nim);

            if(student == null)
            {
                return NotFound(new { message = "Student Not Found." });
            }
            return Ok(student);
        }
    }
}
