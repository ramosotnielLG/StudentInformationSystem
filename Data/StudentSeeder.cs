using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Data;

public static class StudentSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.Students.AnyAsync()) return;

            db.Students.AddRange(
                new Student
                {
                    NIM = "2481010",
                    Name = "Andreas Jacob",
                    Major = "Informatics Engineering",
                    Semester = 5,
                    GPA = 3.5
                },
                new Student
                {
                    NIM = "2481032",
                    Name = "Ramos Otniel Lumban Gaol",
                    Major = "Informatics Engineering",
                    Semester = 5,
                    GPA = 3.5
                },
                new Student
                {
                    NIM = "2481001",
                    Name = "David Sinambela",
                    Major = "Informatics Engineering",
                    Semester = 5,
                    GPA = 3.81
                }
            );
        await db.SaveChangesAsync();
    }
}