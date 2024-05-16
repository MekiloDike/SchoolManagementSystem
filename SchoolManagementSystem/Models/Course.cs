using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? CourseName { get; set; }

        //many to many
        public virtual List<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
