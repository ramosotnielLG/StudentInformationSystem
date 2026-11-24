/*
 NIM: 2481032
 Name: Ramos Otniel Lumban Gaol
 Course: Framework .NET Programming
 */

namespace StudentInformationSystem.Models
{
    public class Student
    {
        //declare every Getter and Setter
        //structure of student
        /*
         */
        public string NIM { get; set; } = "";
        public string Name { get; set; } = "";
        public string Major { get; set; } = "";
        public int Semester { get; set; }
        public double GPA { get; set; }
    }
}
