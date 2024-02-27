using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? CourseName { get; set; }        
        public Teacher? Teacher { get; set; }

        [ForeignKey("StudentCourse")]
        public string? StudentCourseId { get; set; }
        public StudentCourse? StudentCourse { get; set; }
        
    }
}
