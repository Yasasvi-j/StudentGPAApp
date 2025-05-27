using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentGPAApp.Models
{
    public class CourseGrade
    {
        public int CourseGradeId { get; set; }
        [Required(ErrorMessage = "Course Name is required.")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        public string Grade { get; set; }
        


        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }

}
