using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Dtos;

public class StudentWriteRequest
{
    [Required, StringLength(20)]
    public string NIM { get; set; } = "";

    [Required, StringLength(120)]
    public string Name { get; set; } = "";

    [Required, StringLength(100)]
    public string Major { get; set; } = "";

    [Range(1, 14)]
    public int Semester { get; set; }

    [Range(0, 4)]
    public double GPA { get; set; }
}