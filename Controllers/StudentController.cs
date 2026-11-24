/*
Name: Ramos Otniel Lumban Gaol
Student ID: 2481032

*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;

namespace StudentInformationSystem.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _db;

    public StudentController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Profile(string? nim)
    {
        nim ??= "2481032";

        var student = await _db.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.NIM == nim);

        if (student is null) return NotFound();

        return View(student);
    }
}