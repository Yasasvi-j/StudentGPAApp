using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentGPAApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string LastName { get; set; }
        public double GPA { get; set; }

        public List<CourseGrade> Courses { get; set; } = new();

    }
}
