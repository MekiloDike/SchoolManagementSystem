using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models
{
    public class StudentCourse
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("Course")]
        public string? CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
