/*
 NIM: 2481032
 Name: Ramos Otniel Lumban Gaol
 Course: Framework .NET Programming
 */

using StudentInformationSystem.Models;

namespace StudentInformationSystem.Data
{
    public static class StudentData
    {
        public static readonly List<Student> Students = new()
        {
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
        };
    }
}
