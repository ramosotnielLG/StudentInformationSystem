using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using StudentInformationSystem.Data;
using StudentInformationSystem.Dtos;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsApiController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public StudentsApiController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET /api/students
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAll()
    {
        var students = await _db.Students
            .AsNoTracking()
            .OrderBy(s => s.NIM)
            .ToListAsync();

        return Ok(students);
    }

    // GET /api/students/{nim}
    [HttpGet("{nim}")]
    public async Task<ActionResult<Student>> GetByNim(string nim)
    {
        var student = await _db.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.NIM == nim);

        return student is null
            ? NotFound(new { message = "Student not found." })
            : Ok(student);
    }

    // POST /api/students
    [HttpPost]
    public async Task<ActionResult<Student>> Create(StudentWriteRequest request)
    {
        if (await _db.Students.AnyAsync(s => s.NIM == request.NIM))
            return Conflict(new { message = "NIM already exists." });

        var student = new Student
        {
            NIM = request.NIM,
            Name = request.Name,
            Major = request.Major,
            Semester = request.Semester,
            GPA = request.GPA
        };

        _db.Students.Add(student);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (IsDuplicateKey(ex))
        {
            return Conflict(new { message = "NIM already exists." });
        }

        return CreatedAtAction(nameof(GetByNim), new { nim = student.NIM }, student);
    }

    // PUT /api/students/{nim}
    [HttpPut("{nim}")]
    public async Task<IActionResult> Update(string nim, StudentWriteRequest request)
    {
        if (nim != request.NIM)
            return BadRequest(new { message = "Route NIM must match body NIM." });

        var student = await _db.Students
            .FirstOrDefaultAsync(s => s.NIM == nim);

        if (student is null)
            return NotFound(new { message = "Student not found." });

        student.Name = request.Name;
        student.Major = request.Major;
        student.Semester = request.Semester;
        student.GPA = request.GPA;

        await _db.SaveChangesAsync();

        return NoContent();
    }

    // DELETE /api/students/{nim}
    [HttpDelete("{nim}")]
    public async Task<IActionResult> Delete(string nim)
    {
        var student = await _db.Students
            .FirstOrDefaultAsync(s => s.NIM == nim);

        if (student is null)
            return NotFound(new { message = "Student not found." });

        _db.Students.Remove(student);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    private static bool IsDuplicateKey(DbUpdateException ex) =>
        ex.InnerException is MySqlException mysql && mysql.Number == 1062;
}